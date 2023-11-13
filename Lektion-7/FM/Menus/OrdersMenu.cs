namespace FM.Menus;

internal class OrdersMenu
{
    public async Task ShowAsync()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Show all Orders");
            Console.WriteLine("2. Add new Order");
            Console.WriteLine("0. Go Back");

            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":

                    break;

                case "2":

                    break;

                case "0":
                    exit = true;
                    break;
            }
        }
        while (!exit);
    }
}
