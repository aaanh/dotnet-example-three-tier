using Microsoft.AspNetCore.Mvc.RazorPages;
using example_three_tier.Business.Services;
using example_three_tier.Business.Dtos;

namespace example_three_tier.Web.Pages;

public class CustomersModel : PageModel
{
  private readonly CustomerService _service;

  public string ErrorMessage { get; set; } = "";
  public CustomersModel(CustomerService service)
  {
    _service = service;
  }

  // Property exposed to Razor Page
  public List<CustomerDto> Customers { get; set; } = new();


  // Called on HTTP GET /Customers
  public void OnGet()
  {
    try
    {
      // For now fetch customers 1..3
      var list = new List<CustomerDto>();
      for (int i = 1; i <= 3; i++)
      {
        var c = _service.GetCustomer(i);
        if (c != null)
          list.Add(c);
      }
      Customers = list;
    }
    catch (Exception)
    {
      Customers = new List<CustomerDto>();
      ErrorMessage = "Database not available, please try again later.";
    }
  }
}
