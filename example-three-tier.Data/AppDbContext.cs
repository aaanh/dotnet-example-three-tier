using Microsoft.EntityFrameworkCore;
using example_three_tier.Data.Entities;

namespace example_three_tier.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Customer> Customers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Seed initial Customers
    modelBuilder.Entity<Customer>().HasData(
        new Customer { Id = 1, Name = "Alice Johnson" },
        new Customer { Id = 2, Name = "Bob Smith" },
        new Customer { Id = 3, Name = "Charlie Brown" }
    );
  }
}
