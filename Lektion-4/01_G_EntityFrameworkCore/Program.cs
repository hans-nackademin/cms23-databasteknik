using _01_G_EntityFrameworkCore.Entities;
using _01_G_EntityFrameworkCore.Services;

Console.WriteLine("");

/* 
    Steg 1:     Installera NuGet Paket 
                    Microsoft.EntityFrameworkCore.SqlServer
                    Microsoft.EntityFrameworkCore.Tools
 
    Steg 2:     Göra entiteter (klasser/modeller/objekt/tabeller)
                    UserEntity              = tabell för att lagra användarinformation
                    AddressEntity           = tabell för att lagra adressinformation
                    RoleEntity              = tabell för att lagra användarroller
   
    Steg 3:     Skapa en databas och hämta connectionstring för den databasen
                    g_database    Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-4\01_G_EntityFrameworkCore\Contexts\g_database.mdf;Integrated Security=True;Connect Timeout=30      

    Steg 4:     Skapa en Context som ärver ifrån DbContext och lagt in våra entiteter
                    DataContext             = en context som hanterar kopplingen till databasen
 
    Steg 5:     Göra en Add-Migration för att kontrollera alla kopplingar (måste göras i Package Manager Console)
                    Add-Migration "Ange ett lämpligt migreringsnamn, börja på stor bokstav"

    Steg 6:     Kontrollera så att vår Migration stämmer, om den stämmer gör en Update-Database annars Remove-Migration
                Update-Database             = sparar och skapar alla tabeller i databasen
 
    Steg 7:     Skapa en Service som ska hantera CRUD till/från databasen
                UserService                 = hanterar CRUD för användare
                AddressService              = hanterar CRUD för adresser
                RoleService                 = hanterar CRUD för roller

    Steg 8:     Testa programmet!
*/


var userEntity = new UserEntity
{
    FirstName = "Tommy",
    LastName = "Mattin-Lassei",
    Email = "tommy@domain.com",
    Password = "BytMig123!",

    Address = new AddressEntity
    {
        StreetName = "Nordkapsvägen 1",
        PostalCode = "136 57",
        City = "Vega"
    },
    Role = new RoleEntity
    {
        RoleName = "Administratör"
    }
};

var userService = new UserService();
var user = await userService.CreateAsync(userEntity);

Console.WriteLine($"UserId: {user.Id}");
Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
Console.ReadKey();