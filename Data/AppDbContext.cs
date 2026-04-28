using Microsoft.EntityFrameworkCore;
using PipelineProject.Model;

namespace PipelineProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Product> Products {get; set;}
    }
}