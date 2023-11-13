using _01_Database_with_SqlClient.Models;
using _01_Database_with_SqlClient.Services;


var product = new Product()
{
    Name = "Logitech G535 LIGHTSPEED Wireless Gaming Headset - BLACK",
    Description = "Bekvämt gamingheadset med hög prestanda",
    Price = 890
};


var productService = new ProductService();
var productId = productService.Create(product);

foreach (var item in productService.GetAll())
    Console.WriteLine($"{item.Name} ({item.Price} kr)");




product.Id = (int)productId!;
product.Description = "Logitech G535 är ett trådlöst gaming headset som är har hög prestanda med låg latens, fri från jobbiga sladdar och bekvämlighet som varar i timmar. Hörlurarna har avancerad, trådlös LIGHTSPEED och en batteritid på 33 timmar. Batteritiden baseras på att volymen är inställd på 50 %. Högtalarelement på 40 mm för klart och fylligt ljud som gör din gamingupplevelse ennu bättre. De är lätta och smidiga och väger endast 236 gram och med en justerbar bygel och öronkuddar i mjukt minnesskum vilket säkerställer att de är bekväma under hela dina spelsessioner.";
product.Price = 1119;
productService.Update(product);

foreach (var item in productService.GetAll())
    Console.WriteLine($"{item.Name} ({item.Price} kr)");

Console.ReadKey();

