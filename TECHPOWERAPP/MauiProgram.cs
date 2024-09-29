using Microsoft.Extensions.Logging;

namespace TECHPOWERAPP
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
                    fonts.AddFont("School.otf", "School");
                    fonts.AddFont("Background.otf", "Background");
                    fonts.AddFont("Family Vacation.otf", "Family Vacation");
                    fonts.AddFont("Basote.ttf", "Basote");
                    fonts.AddFont("McAlesterDemoRegular.ttf", "McAlesterDemoRegular");

                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
