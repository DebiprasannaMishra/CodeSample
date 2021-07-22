using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ApiApp;trusted_connection=true;");
        }
    }
}
