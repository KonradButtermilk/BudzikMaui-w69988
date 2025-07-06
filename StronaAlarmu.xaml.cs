using MauiCatAlarm.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiCatAlarm;

/// <summary>
/// Strona wyświetlana podczas dzwonienia budzika.
/// </summary>
public partial class StronaAlarmu : ContentPage
{
    public StronaAlarmu(AlarmModelWidoku alarmViewModel)
    {
        BindingContext = alarmViewModel;
        InitializeComponent();
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        ((AlarmModelWidoku)BindingContext).Window = Window;
    }
}
