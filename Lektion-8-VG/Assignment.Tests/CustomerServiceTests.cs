using Assignment.Entities;
using Assignment.Models;
using Assignment.Repositories;
using Assignment.Services;
using Moq;
using System.Linq.Expressions;

namespace Assignment.Tests;

public class CustomerServiceTests
{
    [Fact]
    public async Task CreateCustomerAsync_NewCustomer_ReturnsTrue()
    {
        // Arrange
        var addressEntity = new AddressEntity { Id = 1, StreetName = "Testvägen 1", PostalCode = "12345", City = "Teststad" };
        var customerTypeEntity = new CustomerTypeEntity { Id = 1, CustomerTypeName = "Privatperson" };
        var form = new CustomerRegistrationForm
        {
            FirstName = "Hans",
            LastName = "Mattin-Lassei",
            Email = "hans@domain.com",
            StreetName = "Testvägen 1",
            PostalCode = "12345",
            City = "Teststad",
            CustomerType = "Privatperson"
        };

        var customerEntity = new CustomerEntity
        {
            Id = 1,
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            AddressId = addressEntity.Id,
            CustomerTypeId = customerTypeEntity.Id
        };

        var mockAddressRepo = new Mock<IAddressRepository>();
        var mockCustomerRepo = new Mock<ICustomerRepository>();
        var mockCustomerTypeRepo = new Mock<ICustomerTypeRepository>();

        // kolla om det finns en kund med samma email redan
        mockCustomerRepo
            .Setup(repo => repo.ExistsAsync(x => x.Email == form.Email))
            .ReturnsAsync(false);

        mockAddressRepo
            .Setup(repo => repo.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode))
            .ReturnsAsync(addressEntity);
        
        mockCustomerTypeRepo
            .Setup(repo => repo.GetAsync(x => x.CustomerTypeName == form.CustomerType))
            .ReturnsAsync(customerTypeEntity);

        mockCustomerRepo
            .Setup(repo => repo.CreateAsync(customerEntity))
            .ReturnsAsync(customerEntity);


        ICustomerService customerService = new CustomerService(mockAddressRepo.Object, mockCustomerRepo.Object, mockCustomerTypeRepo.Object);

        // Act
        var result = await customerService.CreateCustomerAsync(form);

        // Assert
        Assert.True(result);
    }
}
