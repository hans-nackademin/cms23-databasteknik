namespace FM.Menus;

internal class CustomersMenu
{
    public async Task ShowAsync()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Show all Customers");
            Console.WriteLine("2. Add new Customer");
            Console.WriteLine("3. Show all Customer Types");
            Console.WriteLine("4. Add new Customer Type");
            Console.WriteLine("0. Go Back");

            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":

                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "0":
                    exit = true;
                    break;
            }
        }
        while (!exit);
    }
}
