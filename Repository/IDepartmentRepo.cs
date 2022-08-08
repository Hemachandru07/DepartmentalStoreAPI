using DepartmentalStore.Models;

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
        public Task<List<Beverages>> GetAllBeverages();
        public Task<Beverages> GetBeveragesById(int id);
        public Task<Beverages> AddBeverages(Beverages beverages);
        public Task<Beverages> UpdateBeverages(Beverages beverages);
        public Task<Beverages> DeleteBeverages(int id);
        #endregion

        #region Vegetables 
        public Task<List<Vegetables>> GetAllVegetables();
        public Task<Vegetables> GetVegetablesById(int id);
        public Task<Vegetables> AddVegetables(Vegetables vegetables);
        public Task<Vegetables> UpdateVegetables(Vegetables vegetables);
        public Task<Vegetables> DeleteVegetables(int id);
        #endregion

        #region Customer
        public Task<List<Customer>> GetAllCustomer();
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(int id);
        #endregion


    }
}
