using MauiCatAlarm.Services;
using MauiCatAlarm.ViewModels;

using Microsoft.Extensions.Logging;

namespace MauiCatAlarm;
/// <summary>
/// Konfiguracja aplikacji MAUI i rejestracja usług.
/// </summary>
public static class ProgramMaui
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<Aplikacja>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("PublicSans-Regular.ttf", "Public Sans");
                fonts.AddFont("SpaceGrotesk-Regular.ttf", "Space Grotesk");
                fonts.AddFont("SpaceGrotesk-Bold.ttf", "Space Grotesk Bold");
            });

        builder.Services.AddTransient<GlownyModelWidoku>();
        builder.Services.AddTransient<AlarmModelWidoku>();

        builder.Services.AddTransient<StronaGlowna>();
        builder.Services.AddTransient<Func<StronaGlowna>>(provider =>
        {
            return () => provider.GetRequiredService<StronaGlowna>();
        });
        builder.Services.AddTransient<PowlokaAplikacji>();
        builder.Services.AddTransient<Func<PowlokaAplikacji>>(provider =>
        {
            return () => provider.GetRequiredService<PowlokaAplikacji>();
        });
        builder.Services.AddTransient<StronaAlarmu>();
        builder.Services.AddTransient<Func<StronaAlarmu>>(provider =>
        {
            return () => provider.GetRequiredService<StronaAlarmu>();
        });
        builder.Services.AddTransient<IChallengeFactory, BasicChallengeFactory>();
        builder.Services.AddSingleton<SerwisAlarmu>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
