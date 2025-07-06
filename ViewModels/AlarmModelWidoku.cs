using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCatAlarm.Services;
using Microsoft.Maui.Controls;

namespace MauiCatAlarm.ViewModels;

/// <summary>
/// Model widoku obsługujący wyzwania podczas trwania alarmu.
/// </summary>
public partial class AlarmModelWidoku : ObservableObject
{
    private readonly IChallengeFactory _challengeFactory;
    private readonly SerwisAlarmu _serwisAlarmu;

    public AlarmModelWidoku(IChallengeFactory challengeFactory, SerwisAlarmu serwisAlarmu)
    {
        _challengeFactory = challengeFactory;
        _serwisAlarmu = serwisAlarmu;
        NoweWyzwanie();
    }

    /// <summary>Aktualnie wyświetlane zadanie.</summary>
    [ObservableProperty]
    private Wyzwanie? _challenge;

    /// <summary>Tekst wpisany przez użytkownika jako odpowiedź.</summary>
    [ObservableProperty]
    private string _challengeEntryText = string.Empty;

    public Window? Window { get; set; }

    /// <summary>
    /// Generuje nowe zadanie dla użytkownika.
    /// </summary>
    private void NoweWyzwanie()
    {
        Challenge = _challengeFactory.CreateChallenge();
        ChallengeEntryText = string.Empty;
    }

    /// <summary>Polecenie generujące kolejne zadanie.</summary>
    [RelayCommand]
    private void NewChallenge()
    {
        NoweWyzwanie();
    }

    /// <summary>Próbuje wyłączyć alarm jeśli odpowiedź jest prawidłowa.</summary>
    [RelayCommand]
    private void DismissAlarm()
    {
        if (Challenge is not null && Challenge.Validate(ChallengeEntryText))
        {
            _serwisAlarmu.WylaczAlarm();
            Window?.Close();
        }
    }
}
