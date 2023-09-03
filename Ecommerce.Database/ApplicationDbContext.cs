using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {
           
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "Server=IT-Shamsur;Database=EcommerceDB;Trusted_Connection= True;TrustServerCertificate=True";
            //optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
