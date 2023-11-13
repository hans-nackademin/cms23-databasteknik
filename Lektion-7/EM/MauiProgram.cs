using EM.Repositories;
using EM.Services;
using Microsoft.Extensions.Logging;

namespace EM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var databasePath = DatabasePathFinder.GetPath();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton(new ProductRepository(databasePath));
            builder.Services.AddSingleton(new CategoryRepository(databasePath));

            return builder.Build();
        }
    }
}