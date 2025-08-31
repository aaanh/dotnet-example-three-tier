using example_three_tier.Data.Entities;

namespace example_three_tier.Data.Repositories;

public interface ICustomerRepository
{
  Customer GetById(int id);
}