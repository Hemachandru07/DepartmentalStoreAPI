using DepartmentalStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentalStore.Repository
{
    public interface IDepartmentRepo
    {
        #region Fruits 
        public Task<IEnumerable<Fruits>> GetAllFruits();
        public Task<Fruits> GetFruitsById(int id);
        public Task<Fruits> AddFruits(Fruits fruits);
        public Task<Fruits> UpdateFruits(Fruits fruits);
        public Task<Fruits> DeleteFruits(int id);
        #endregion

        #region Groceries 
        public Task<IEnumerable<Groceries>> GetAllGroceries();
        public Task<Groceries> GetGroceriesById(int id);
        public Task<Groceries> AddGroceries(Groceries groceries);
        public Task<Groceries> UpdateGroceries(Groceries groceries);
        public Task<Groceries> DeleteGroceries(int id);
        #endregion

        #region Beverages 
        public Task<IEnumerable<Beverages>> GetAllBeverages();
        public Task<Beverages> GetBeveragesById(int id);
        public Task<Beverages> AddBeverages(Beverages beverages);
        public Task<Beverages> UpdateBeverages(Beverages beverages);
        public Task<Beverages> DeleteBeverages(int id);
        #endregion

        #region Vegetables 
        public Task<IEnumerable<Vegetables>> GetAllVegetables();
        public Task<Vegetables> GetVegetablesById(int id);
        public Task<Vegetables> AddVegetables(Vegetables vegetables);
        public Task<Vegetables> UpdateVegetables(Vegetables vegetables);
        public Task<Vegetables> DeleteVegetables(int id);
        #endregion

        #region Customer
        public Task<IEnumerable<Customer>> GetAllCustomer();
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(int id);
        public Task<string> Login(Customer customer);
        #endregion

        #region OrderDetails
        public Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        public Task<OrderDetail> GetOrderDetailById(int id);
        public Task<OrderDetail> AddOrderDetail(OrderDetail orderdetails);
        public Task<OrderDetail> UpdateOrderDetail(OrderDetail orderdetails);
        public Task<OrderDetail> DeleteOrderDetail(int id);
        #endregion


    }
}
