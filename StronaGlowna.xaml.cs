using MauiCatAlarm.ViewModels;

namespace MauiCatAlarm;

/// <summary>
/// Strona główna aplikacji prezentująca bieżący czas i ustawienia budzika.
/// </summary>
public partial class StronaGlowna : ContentPage
{
    public StronaGlowna(GlownyModelWidoku mainPageViewModel)
    {
        BindingContext = mainPageViewModel;

        InitializeComponent();
    }
}
