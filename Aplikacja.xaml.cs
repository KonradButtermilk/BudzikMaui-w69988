using MauiCatAlarm.Services;

using Microsoft.Extensions.Logging;

namespace MauiCatAlarm;

/// <summary>
/// Główna klasa aplikacji budzika.
/// </summary>
public partial class Aplikacja : Application
{
    private readonly IServiceScope _serviceScope;
    private bool _isAlarmActive;

    public Aplikacja(SerwisAlarmu alarmService, IServiceProvider serviceProvider, ILogger<Aplikacja> logger)
    {
        _serviceScope = serviceProvider.CreateScope();

        InitializeComponent();

        // Ładujemy powłokę aplikacji z kontenera usług
        MainPage = ServiceProvider.GetRequiredService<PowlokaAplikacji>();
        alarmService.EnsureAlarmIsSetIfEnabled();
    }

    // Ułatwia dostęp do bieżącej instancji aplikacji
    public static new Aplikacja Current => (Aplikacja)Application.Current!;

    public IServiceProvider ServiceProvider => _serviceScope.ServiceProvider;

    public bool IsAlarmActive
    {
        get => _isAlarmActive;
        set
        {
            if (_isAlarmActive != value)
            {
                _isAlarmActive = value;
                OnPropertyChanged(nameof(IsAlarmActive));
            }
        }
    }

    protected override void CleanUp()
    {
        _serviceScope.Dispose();
        base.CleanUp();
    }
}
