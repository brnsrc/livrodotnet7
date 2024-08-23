using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;
using WorkingWithEFCore;

namespace Packt.Shared;
//this manages the connection to the database
public class Northwind : DbContext
{
    //these properties map to tables in the database
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        string connection = $"Filename={path}";

        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = previousColor;
        
        optionsBuilder.UseSqlite(connection);
        optionsBuilder.LogTo(WriteLine, new[] {RelationalEventId.CommandExecuting}).EnableSensitiveDataLogging(); //console
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // example of using Fluent API instead of atributes
        // to limit the length of a category name to 15
        modelBuilder.Entity<Category>().Property(category => category.CategoryName)
        .IsRequired() // not null
        .HasMaxLength(15);
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            //added to "fix" te lack of decimal support in SQLite
            modelBuilder.Entity<Product>().Property(product => product.Cost)
            .HasConversion<double>();
        }
        
    }
}
