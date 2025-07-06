using MauiCatAlarm;

namespace MauiCatAlarm.Services;

/// <summary>
/// Interfejs fabryki wyzwań matematycznych.
/// </summary>
public interface IChallengeFactory
{
    /// <summary>Tworzy nowe wyzwanie.</summary>
    Wyzwanie CreateChallenge();
}
