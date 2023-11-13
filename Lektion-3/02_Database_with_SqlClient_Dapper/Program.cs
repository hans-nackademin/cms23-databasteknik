using _02_Database_with_SqlClient_Dapper.Models;
using _02_Database_with_SqlClient_Dapper.Services;

var userService = new UserService();
var user = new User
{
    Address = new Address()
};

Console.Write("Ange förnamn: ");
user.FirstName = Console.ReadLine()!;
Console.Write("Ange efternamn: ");
user.LastName = Console.ReadLine()!;
Console.Write("Ange e-postadress: ");
user.Email = Console.ReadLine()!;

Console.Write("Ange gatunamn: ");
user.Address.StreetName = Console.ReadLine()!;
Console.Write("Ange postnummer: ");
user.Address.PostalCode = Console.ReadLine()!;
Console.Write("Ange ort: ");
user.Address.City = Console.ReadLine()!;

var result = userService.CreateUser(user);
if (result)
    Console.WriteLine("Användaren skapades");
else
    Console.WriteLine("Något gick fel");
Console.ReadKey();