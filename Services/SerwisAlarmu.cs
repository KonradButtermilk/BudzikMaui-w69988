using System.Timers;

namespace MauiCatAlarm.Services;

/// <summary>
/// Odpowiada za logikę budzika i monitorowanie czasu.
/// </summary>
public class SerwisAlarmu
{
    // Timer sprawdzający czy nadeszła godzina alarmu
    private readonly Timer _timer = new(1000);

    public event Action? AlarmWywolany;

    public TimeSpan GodzinaAlarmu { get; private set; }
    public bool CzyWlaczony { get; private set; }

    public SerwisAlarmu()
    {
        _timer.Elapsed += SprawdzAlarm;
    }

    /// <summary>Włącza alarm o podanej godzinie.</summary>
    public void UstawAlarm(TimeSpan godzina)
    {
        GodzinaAlarmu = godzina;
        CzyWlaczony = true;
        EnsureAlarmIsSetIfEnabled();
    }

    /// <summary>Wyłącza aktualny alarm.</summary>
    public void WylaczAlarm()
    {
        CzyWlaczony = false;
        _timer.Stop();
    }

    /// <summary>
    /// Sprawdza czy alarm jest włączony i uruchamia timer.
    /// </summary>
    public void EnsureAlarmIsSetIfEnabled()
    {
        if (CzyWlaczony)
        {
            _timer.Start();
        }
    }

    private void SprawdzAlarm(object? sender, ElapsedEventArgs e)
    {
        if (!CzyWlaczony)
            return;

        var teraz = DateTime.Now.TimeOfDay;
        if (teraz.Hours == GodzinaAlarmu.Hours && teraz.Minutes == GodzinaAlarmu.Minutes)
        {
            AlarmWywolany?.Invoke();
        }
    }
}
