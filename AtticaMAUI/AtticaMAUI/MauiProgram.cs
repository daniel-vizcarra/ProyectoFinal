using Microsoft.Extensions.Logging;
using AtticaMAUI.Services;
using AtticaMAUI.ViewModels;
using AtticaMAUI.Views;

namespace AtticaMAUI
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
                })
                ;

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<ObradeArteService>();
            builder.Services.AddSingleton<ArtistaService>();

            builder.Services.AddTransient<ObradeArtesViewModel>();
            builder.Services.AddTransient<ObradeArteDetailViewModel>();

            builder.Services.AddTransient<ObradeArtesPage>();
            builder.Services.AddTransient<ObradeArteDetailPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
