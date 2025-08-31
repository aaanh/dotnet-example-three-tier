using example_three_tier.Business.Dtos;
using example_three_tier.Data.Repositories;

namespace example_three_tier.Business.Services;

public class CustomerService
{
  private readonly ICustomerRepository _repo;
  public CustomerService(ICustomerRepository repo) => _repo = repo;

  public CustomerDto GetCustomer(int id)
  {
    var entity = _repo.GetById(id);
    if (entity == null) return null;

    return new CustomerDto { Id = entity.Id, Name = entity.Name };
  }
}