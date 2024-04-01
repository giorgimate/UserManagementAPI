using Microsoft.AspNetCore.Mvc;
using Moq;
using UserManagement.API.Controllers;
using UserManagement.Application;
using UserManagement.Application.Customers;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Customers.Requests;
using UserManagement.Application.Customers.Respones;
using UserManagement.Application.Exeptions;
using UserManagement.Domain.Customers;

namespace UserManagement.Tests;

public class CustomerServiceTests
{
    #region Create Endpoint

    [Fact]
    public async Task CreateValidCustomer()
    {
        var customer = new CustomerRequestPostModel
        {
            FirstName = "Barry",
            LastName = "White",
            Email = "white@example.com",
            Password = "password123",
            Wallet = 100
        };

        var customerService = new Mock<ICustomerService>();
        customerService.Setup(x => x.CreateAsync(CancellationToken.None, customer)).ReturnsAsync(true);

        var controller = new CustomerController(customerService.Object);

        var result = await controller.Create(CancellationToken.None, customer) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.True((bool)result.Value);
    }

    [Fact]
    public async Task CreateCustomerWithNegativeWallet()
    {
        var customer = new CustomerRequestPostModel
        {
            FirstName = "Barry",
            LastName = "White",
            Email = "white@example.com",
            Password = "password123",
            Wallet = -100
        };

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.CreateAsync(CancellationToken.None, customer)).ThrowsAsync(new AmmountException("Ammount Exception"));

        var controller = new CustomerController(service.Object);

        await Assert.ThrowsAsync<AmmountException>(() => controller.Create(CancellationToken.None, customer));
    }

    [Fact]
    public async Task CreateExistingCustomer()
    {
        var customer = new CustomerRequestPostModel
        {
            FirstName = "Barry",
            LastName = "White",
            Email = "white@example.com",
            Password = "password123",
            Wallet = 100
        };

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.CreateAsync(CancellationToken.None, customer)).ThrowsAsync(new CustomerAlreadyExistException("Customer Already Exist Exception"));

        var controller = new CustomerController(service.Object);

        await Assert.ThrowsAsync<CustomerAlreadyExistException>(() => controller.Create(CancellationToken.None, customer));
    }

    #endregion

    #region Get Endpoint

    [Fact]
    public async Task GetExistingCustomer()
    {
        var expectedCustomer = new CustomerResponseModel
        {
            Id = 1,
            FirstName = "Barry",
            LastName = "White",
            Email = "white@example.com",
            Wallet = 100
        };

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.GetAsync(CancellationToken.None, expectedCustomer.Id)).ReturnsAsync(expectedCustomer);

        var controller = new CustomerController(service.Object);

        var result = await controller.Get(CancellationToken.None, expectedCustomer.Id) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedCustomer, result.Value);
    }

    [Fact]
    public async Task GetNonExistingCustomer()
    {
        var customerId = 1;

        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork.Setup(uow => uow.Customers.GetAsync(CancellationToken.None, customerId)).ReturnsAsync((Customer)null);

        var service = new CustomerService(unitOfWork.Object);

        var controller = new CustomerController(service);

        await Assert.ThrowsAsync<CustomerNotFoundException>(() => controller.Get(CancellationToken.None, customerId));
    }

    [Fact]
    public async Task GetAllCustomers()
    {
        var customers = new List<CustomerResponseModel>
         {
         new() { Id = 1, FirstName = "Barry", LastName = "White", Email = "white@example.com", Wallet = 100 },
         new() { Id = 2, FirstName = "Nick", LastName = "Brown", Email = "brown@example.com", Wallet = 150 }
         };

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.GetAllAsync(CancellationToken.None)).ReturnsAsync(customers);

        var controller = new CustomerController(service.Object);

        var result = await controller.GetAll(CancellationToken.None) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(customers, result.Value);
    }

    [Fact]
    public async Task GetAllCustomersException()
    {

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.GetAllAsync(CancellationToken.None)).ThrowsAsync(new CustomerNotFoundException("Customer Not Found Exception"));

        var controller = new CustomerController(service.Object);

        await Assert.ThrowsAsync<CustomerNotFoundException>(() => controller.GetAll(CancellationToken.None));
    }

    #endregion

    #region Delete Endpoint

    [Fact]
    public async Task DeleteCustomer()
    {
        var cancellationToken = CancellationToken.None;
        var customerId = 1;

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.DeleteAsync(cancellationToken, customerId)).ReturnsAsync(true);

        var controller = new CustomerController(service.Object);

        var result = await controller.Delete(cancellationToken, customerId) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.True((bool)result.Value);
    }

    [Fact]
    public async Task DeleteNonExistingCustomer()
    {
        var cancellationToken = CancellationToken.None;
        var customerId = 1;

        var service = new Mock<ICustomerService>();
        service.Setup(x => x.DeleteAsync(cancellationToken, customerId)).ThrowsAsync(new CustomerNotFoundException("Customer Not Found Exception"));

        var controller = new CustomerController(service.Object);

        await Assert.ThrowsAsync<CustomerNotFoundException>(() => controller.Delete(cancellationToken, customerId));
    }

    #endregion
}