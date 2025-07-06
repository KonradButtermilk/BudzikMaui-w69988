using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCatAlarm.Services;
using Microsoft.Maui.Controls;

namespace MauiCatAlarm.ViewModels;

/// <summary>
/// Model widoku strony głównej.
/// </summary>
public partial class GlownyModelWidoku : ObservableObject
{
    private readonly SerwisAlarmu _serwisAlarmu;
    private readonly Func<StronaAlarmu> _fabrykaStronyAlarmu;

    // Timer aktualizujący wyświetlaną datę i czas
    private readonly Timer _czasTimer = new(1000);

    public GlownyModelWidoku(SerwisAlarmu serwisAlarmu, Func<StronaAlarmu> fabrykaStronyAlarmu)
    {
        _serwisAlarmu = serwisAlarmu;
        _fabrykaStronyAlarmu = fabrykaStronyAlarmu;
        _serwisAlarmu.AlarmWywolany += OnAlarmWywolany;

        _czasTimer.Elapsed += (s, e) => AktualizujCzas();
        _czasTimer.Start();
        AktualizujCzas();
    }

    [ObservableProperty]
    private string _aktualnyCzas = string.Empty;

    [ObservableProperty]
    private string _aktualnyDzien = string.Empty;

    [ObservableProperty]
    private string _aktualnyMiesiac = string.Empty;

    [ObservableProperty]
    private string _numerDnia = string.Empty;

    [ObservableProperty]
    private TimeSpan _godzinaAlarmu = DateTime.Now.AddMinutes(1).TimeOfDay;

    [ObservableProperty]
    private bool _alarmTrwa;

    /// <summary>
    /// Aktualizuje właściwości reprezentujące bieżącą datę i czas.
    /// </summary>
    private void AktualizujCzas()
    {
        var teraz = DateTime.Now;
        AktualnyCzas = teraz.ToString("HH:mm:ss");
        AktualnyDzien = teraz.ToString("dddd");
        AktualnyMiesiac = teraz.ToString("MMM");
        NumerDnia = teraz.Day.ToString();
    }

    /// <summary>
    /// Wywoływane gdy nastąpi czas alarmu.
    /// </summary>
    private void OnAlarmWywolany()
    {
        AlarmTrwa = true;
        Shell.Current.Navigation.PushAsync(_fabrykaStronyAlarmu());
    }

    /// <summary>
    /// Włącza lub wyłącza budzik w zależności od aktualnego stanu.
    /// </summary>
    [RelayCommand]
    private void PrzelaczAlarm()
    {
        if (_serwisAlarmu.CzyWlaczony)
        {
            _serwisAlarmu.WylaczAlarm();
            AlarmTrwa = false;
        }
        else
        {
            _serwisAlarmu.UstawAlarm(GodzinaAlarmu);
        }
        OnPropertyChanged(nameof(TekstPrzelacznika));
    }

    public string TekstPrzelacznika => _serwisAlarmu.CzyWlaczony ? "Wyłącz budzik" : "Ustaw budzik";

    /// <summary>
    /// Otwiera stronę z zadaniem matematycznym.
    /// </summary>
    [RelayCommand]
    private void OtworzStroneAlarmu()
    {
        Shell.Current.Navigation.PushAsync(_fabrykaStronyAlarmu());
    }
}
