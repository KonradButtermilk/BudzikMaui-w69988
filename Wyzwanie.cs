namespace MauiCatAlarm;

/// <summary>
/// Bazowa klasa reprezentująca wyzwanie dla użytkownika.
/// </summary>
public abstract class Wyzwanie
{
    /// <summary>Treść zadania do wyświetlenia.</summary>
    public abstract string Prompt { get; }

    /// <summary>Sprawdza czy odpowiedź jest poprawna.</summary>
    public abstract bool Validate(string response);
}
