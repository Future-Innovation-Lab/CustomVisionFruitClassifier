using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;
using System.Runtime;
using MauiOnDeviceCustomVision.ViewModels;
using MauiOnDeviceCustomVision.Views;
using CommunityToolkit.Maui;

namespace MauiOnDeviceCustomVision
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.RegisterServices().RegisterViewModels().RegisterViews();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            // More services registered here.
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FruitClassifierViewModel>();
            // More view-models registered here.
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FruitClassifierView>();
            // More views registered here.
            return mauiAppBuilder;
        }
    }
}
