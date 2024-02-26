using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeatherMobile.APP.Services;

namespace WeatherMobile.APP
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

            builder.Services.AddScoped<Services.IServices.IWeatherService, WeatherService>();
            builder.Services.AddScoped<ViewModel.WeatherViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
