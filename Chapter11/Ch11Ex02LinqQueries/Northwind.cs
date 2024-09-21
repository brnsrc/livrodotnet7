using Microsoft.EntityFrameworkCore; //DBContext, DBSet<T>

namespace Ch11Ex02LinqQueries;
public class Northwind : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory,
            "Northwind-Ch11Ex02.db");
        optionsBuilder.UseSqlite($"Filename={path}");

    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder){
    //     if (Database.ProviderName.Contains("Sqlite"))
    //     {
    //         modelBuilder.Entity<Customer>()
    //     }
    // }

}
