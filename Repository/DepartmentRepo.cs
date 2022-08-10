using DepartmentalStore.Data;
using DepartmentalStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DepartmentalStore.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DepartmentalStoreDBContext db;
        private readonly IConfiguration _configuration;


        public DepartmentRepo(DepartmentalStoreDBContext _db, IConfiguration configuration)
        {
            db = _db;
            _configuration = configuration;

        }

        #region Fruits
        public async Task<IEnumerable<Fruits>> GetAllFruits()
        {
            return await db.fruits.ToListAsync();
        }
        public async Task<Fruits> GetFruitsById(int id)
        {
            return await db.fruits.FirstOrDefaultAsync(e => e.FruitId == id);
        }
        public async Task<Fruits> AddFruits(Fruits fruits)
        {
            var result = await db.fruits.AddAsync(fruits);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Fruits> UpdateFruits(Fruits fruits)
        {
                db.fruits.Update(fruits);
                await db.SaveChangesAsync();
                return fruits;
        }
        public async Task<Fruits> DeleteFruits(int id)
        {
           
            var result = await db.fruits
                .FirstOrDefaultAsync(e => e.FruitId == id);
            if (result != null)
            {
                db.fruits.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }
        #endregion

        #region Groceries
        public async Task<IEnumerable<Groceries>> GetAllGroceries()
        {
            return await db.groceries.ToListAsync();
        }
        public async Task<Groceries> GetGroceriesById(int id)
        {
            return await db.groceries.FirstOrDefaultAsync(e => e.GroceryId == id);
        }
        public async Task<Groceries> AddGroceries(Groceries groceries)
        {
            var result = await db.groceries.AddAsync(groceries);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Groceries> UpdateGroceries(Groceries groceries)
        {
            db.groceries.Update(groceries);
            await db.SaveChangesAsync();
            return groceries;
        }
        public async Task<Groceries> DeleteGroceries(int id)
        {
            var result = await db.groceries
                 .FirstOrDefaultAsync(e => e.GroceryId == id);
            if (result != null)
            {
                db.groceries.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }
        #endregion

        #region Beverages
        public async Task<IEnumerable<Beverages>> GetAllBeverages()
        {
           return await db.beverages.ToListAsync();
        }
        public async Task<Beverages> GetBeveragesById(int id)
        {
           
            return await db.beverages.FirstOrDefaultAsync(e => e.BeverageId == id);
        }
        public async Task<Beverages> AddBeverages(Beverages beverages)
        {
            var result = await db.beverages.AddAsync(beverages);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Beverages> UpdateBeverages(Beverages beverages)
        {
            db.beverages.Update(beverages);
            await db.SaveChangesAsync();
            return beverages;
        }
        public async Task<Beverages> DeleteBeverages(int id)
        {
            var result = await db.beverages
                 .FirstOrDefaultAsync(e => e.BeverageId == id);
            if (result != null)
            {
                db.beverages.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }
        #endregion

        #region Vegetables
        public async Task<IEnumerable<Vegetables>> GetAllVegetables()
        {
            return await db.vegetables.ToListAsync();
        }
        public async Task<Vegetables> GetVegetablesById(int id)
        {
            return await db.vegetables.FirstOrDefaultAsync(e => e.VegetableId == id);
        }
        public async Task<Vegetables> AddVegetables(Vegetables vegetables)
        {
            var result = await db.vegetables.AddAsync(vegetables);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Vegetables> UpdateVegetables(Vegetables vegetables)
        {
            db.vegetables.Update(vegetables);
            await db.SaveChangesAsync();
            return vegetables;
        }
        public async Task<Vegetables> DeleteVegetables(int id)
        {
            var result = await db.vegetables
                 .FirstOrDefaultAsync(e => e.VegetableId == id);
            if (result != null)
            {
                db.vegetables.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }
        #endregion

        #region Customer
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await db.customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await db.customers.FirstOrDefaultAsync(e => e.CustomerId == id);
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await db.customers.AddAsync(customer);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            db.customers.Update(customer);
            await db.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            var result = await db.customers
                  .FirstOrDefaultAsync(e => e.CustomerId == id);
            if (result != null)
            {
                db.customers.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }

        public async Task<string> Login(Customer customer)
        {
            var user = await db.customers.FindAsync(customer.CustomerId);
            var result = await (from i in db.customers where i.Password == customer.Password && i.CustomerId == customer.CustomerId select i).SingleOrDefaultAsync();
            if (user != null && result != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.CustomerName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };


                var token = GetToken(authClaims);
                return new JwtSecurityTokenHandler().WriteToken(token);
              
            }
            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                ); ;

            return token;
        }

        #endregion

        #region OrderDetails
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            return await db.orderdetails.ToListAsync();
        }
        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await db.orderdetails.FirstOrDefaultAsync(e => e.OrderDetailID == id);
        }
        public async Task<OrderDetail> AddOrderDetail(OrderDetail orderdetails)
        {
            var result = await db.orderdetails.AddAsync(orderdetails);
            await db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderdetails)
        {
            db.orderdetails.Update(orderdetails);
            await db.SaveChangesAsync();
            return orderdetails;
        }
        public async Task<OrderDetail> DeleteOrderDetail(int id)
        {

            var result = await db.orderdetails
                .FirstOrDefaultAsync(e => e.OrderDetailID == id);
            if (result != null)
            {
                db.orderdetails.Remove(result);
                await db.SaveChangesAsync();
            }
            return null;
        }
        #endregion
    }
}
