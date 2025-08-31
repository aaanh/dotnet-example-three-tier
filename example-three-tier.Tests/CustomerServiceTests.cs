using Xunit;
using Moq;
using example_three_tier.Business.Services;
using example_three_tier.Business.Dtos;
using example_three_tier.Data.Entities;
using example_three_tier.Data.Repositories;

namespace example_three_tier.Tests;

public class CustomerServiceTests
{
  [Fact]
  public void GetCustomer_ReturnsDto_WhenCustomerExists()
  {
    // Arrange
    var mockRepo = new Mock<ICustomerRepository>();
    mockRepo.Setup(r => r.GetById(1))
            .Returns(new Customer { Id = 1, Name = "Alice" });

    var service = new CustomerService(mockRepo.Object);

    // Act
    var result = service.GetCustomer(1);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(1, result.Id);
    Assert.Equal("Alice", result.Name);
  }

  [Fact]
  public void GetCustomer_ReturnsNull_WhenCustomerNotFound()
  {
    // Arrange
    var mockRepo = new Mock<ICustomerRepository>();
    mockRepo.Setup(r => r.GetById(99))
            .Returns((Customer)null);

    var service = new CustomerService(mockRepo.Object);

    // Act
    var result = service.GetCustomer(99);

    // Assert
    Assert.Null(result);
  }
}
