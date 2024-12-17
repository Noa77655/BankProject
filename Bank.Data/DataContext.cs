using Microsoft.EntityFrameworkCore;
using project.Entitis;


namespace project
{
    public class DataContext :  DbContext
    {
        public DbSet<Banker> bankers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Turn> turns { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=bank");
        }
    }

}
