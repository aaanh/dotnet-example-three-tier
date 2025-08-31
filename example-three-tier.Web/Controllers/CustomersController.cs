using Microsoft.AspNetCore.Mvc;
using example_three_tier.Business.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace example_three_tier.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
  private readonly CustomerService _service;
  public CustomersController(CustomerService service) => _service = service;

  [HttpGet("{id}")]
  public IActionResult Get(int id)
  {
    try
    {
      var customer = _service.GetCustomer(id);
      if (customer == null)
        return NotFound();
      return Ok(customer);
    }
    catch (Exception ex)
    {
      return StatusCode(503, $"Database unavailable: {ex.Message}");
    }
  }

}