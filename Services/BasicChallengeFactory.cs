using MauiCatAlarm;

namespace MauiCatAlarm.Services;

/// <summary>
/// Prosta implementacja <see cref="IChallengeFactory"/> zwracająca zadania dodawania.
/// </summary>
public class BasicChallengeFactory : IChallengeFactory
{
    public Wyzwanie CreateChallenge()
    {
        // Zwraca zadanie matematyczne o losowych składnikach
        return MatematyczneWyzwanie.CreateAdditionChallenge();
    }
}
