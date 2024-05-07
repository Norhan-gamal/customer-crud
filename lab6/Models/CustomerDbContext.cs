using Microsoft.EntityFrameworkCore;

namespace lab6.Models
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext() : base()
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CustomerOrders;Integrated Security=True; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
