namespace FM.Menus;

internal class MainMenu
{
    private readonly ProductsMenu _productsMenu;
    private readonly CustomersMenu _customersMenu;
    private readonly OrdersMenu _ordersMenu;

    public MainMenu(ProductsMenu productsMenu, CustomersMenu customersMenu, OrdersMenu ordersMenu)
    {
        _productsMenu = productsMenu;
        _customersMenu = customersMenu;
        _ordersMenu = ordersMenu;
    }

    public async Task ShowAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("1. Go To Products");
            Console.WriteLine("2. Go To Customers");
            Console.WriteLine("3. Go To Orders");
            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":
                    await _productsMenu.ShowAsync();
                    break;
                case "2":
                    await _customersMenu.ShowAsync();
                    break;
                case "3":
                    await _ordersMenu.ShowAsync();
                    break;
            }
        }
        while (true);
    }
}
