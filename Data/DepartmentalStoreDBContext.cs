using DepartmentalStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentalStore.Data
{
    public class DepartmentalStoreDBContext : DbContext
    {
        public DepartmentalStoreDBContext() { }
        public DepartmentalStoreDBContext(DbContextOptions options) : base(options) { }
        public DbSet<AdminMaster> adminmasters { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Fruits> fruits { get; set; }
        public DbSet<Vegetables> vegetables { get; set; }
        public DbSet<Beverages> beverages { get; set; }
        public DbSet<Groceries> groceries { get; set; }
        public DbSet<OrderMaster> ordermasters { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
    }
}
