using example_three_tier.Data.Entities;

namespace example_three_tier.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
  private readonly AppDbContext _ctx;
  public CustomerRepository(AppDbContext ctx) => _ctx = ctx;

  public Customer GetById(int id) => _ctx.Customers.Find(id);
}