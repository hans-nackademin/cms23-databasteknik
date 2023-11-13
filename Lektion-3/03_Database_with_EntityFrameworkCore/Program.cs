using _03_Database_with_EntityFrameworkCore.Models.Entities;
using _03_Database_with_EntityFrameworkCore.Services;

var userService = new UserService();

var user = new UserEntity()
{
    FirstName = "Hans",
    LastName = "Mattin-Lassei",
    Email = "hans@domain.com",
    Address = new AddressEntity
    {
        StreetName = "Nordkapsvägen 1",
        PostalCode = "136 57",
        City = "Vega"
    }
};

userService.CreateUser(user);
Console.ReadKey();