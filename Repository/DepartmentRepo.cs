using DepartmentalStore.Data;
using DepartmentalStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentalStore.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DepartmentalStoreDBContext db;
        public DepartmentRepo(DepartmentalStoreDBContext _db)
        {
            db = _db;
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
        public async Task<List<Beverages>> GetAllBeverages()
        {
           return await db.beverages.ToListAsync();
        }
        public async Task<Beverages> GetBeveragesById(int id)
        {
            return await db.beverages.FindAsync(id);
        }
        public async Task<Beverages> AddBeverages(Beverages beverages)
        {
            db.beverages.Add(beverages);
            await db.SaveChangesAsync();
            return beverages;
        }
        public async Task<Beverages> UpdateBeverages(Beverages beverages)
        {
            db.beverages.Update(beverages);
            await db.SaveChangesAsync();
            return beverages;
        }
        public async Task<Beverages> DeleteBeverages(int id)
        {
            var delete = await db.beverages.FindAsync(id);
            db.beverages.Remove(delete);
            await db.SaveChangesAsync();
            return delete;
        }
        #endregion

        #region Vegetables
        public async Task<List<Vegetables>> GetAllVegetables()
        {
            return await db.vegetables.ToListAsync();
        }
        public async Task<Vegetables> GetVegetablesById(int id)
        {
            return await db.vegetables.FindAsync(id);
        }
        public async Task<Vegetables> AddVegetables(Vegetables vegetables)
        {
            db.vegetables.Add(vegetables);
            await db.SaveChangesAsync();
            return vegetables;
        }
        public async Task<Vegetables> UpdateVegetables(Vegetables vegetables)
        {
            db.vegetables.Update(vegetables);
            await db.SaveChangesAsync();
            return vegetables;
        }
        public async Task<Vegetables> DeleteVegetables(int id)
        {
            var delete = await db.vegetables.FindAsync(id);
            db.vegetables.Remove(delete);
            await db.SaveChangesAsync();
            return delete;
        }
        #endregion

        #region Customer
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await db.customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await db.customers.FindAsync(id);
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            db.customers.Add(customer);
            await db.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            db.customers.Update(customer);
            await db.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            var delete = await db.customers.FindAsync(id);
            db.customers.Remove(delete);
            await db.SaveChangesAsync();
            return delete;
        }
        #endregion
    }
}
