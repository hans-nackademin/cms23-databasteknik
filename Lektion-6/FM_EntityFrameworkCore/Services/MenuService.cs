using FM_EntityFrameworkCore.Entities;

namespace FM_EntityFrameworkCore.Services;

internal class MenuService
{
    private readonly CustomerTypeService _customerTypeService;

    public MenuService(CustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task CreateCustomerTypeMenuAsync()
    {
        var customerTypeEntity = new CustomerTypeEntity();

        Console.Clear();
        Console.Write("Enter Customer Type: ");
        customerTypeEntity.TypeName = Console.ReadLine()!;

        var result = await _customerTypeService.CreateAsync(customerTypeEntity);
        
        if (result)
            Console.WriteLine($"Customer Type {customerTypeEntity.TypeName} was created");
        else
            Console.WriteLine($"Customer Type {customerTypeEntity.TypeName} already exists");

        Console.ReadKey();
    }
}
