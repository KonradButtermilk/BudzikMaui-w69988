namespace MauiCatAlarm;

/// <summary>
/// Proste wyzwanie matematyczne używane do wyłączania budzika.
/// </summary>
public class MatematyczneWyzwanie(string prompt, Func<double, bool> validator) : Wyzwanie
{
    // Funkcja weryfikująca poprawność odpowiedzi
    private readonly Func<double, bool> _validator = validator;

    public override string Prompt { get; } = prompt;

    public static MatematyczneWyzwanie CreateAdditionChallenge(Difficulty difficulty = Difficulty.Easy)
    {
        var (min, max) = difficulty switch
        {
            Difficulty.Easy => (1, 10),
            Difficulty.Normal => (10, 100),
            Difficulty.Hard => (100, 1000),
            Difficulty.Insane => (1000, 10000),
            _ => (1, 10)
        };

        var a = Random.Shared.Next(min, max);
        var b = Random.Shared.Next(min, max);
        return new MatematyczneWyzwanie(
            $"{a} + {b} = ?",
            answer => answer == a + b);
    }

    public static MatematyczneWyzwanie CreateMultiplicationChallenge(Difficulty difficulty = Difficulty.Easy)
    {
        var (min, max) = difficulty switch
        {
            Difficulty.Easy => (2, 10),
            Difficulty.Normal => (11, 20),
            Difficulty.Hard => (21, 50),
            Difficulty.Insane => (51, 100),
            _ => (2, 10)
        };

        var a = Random.Shared.Next(min, max);
        var b = Random.Shared.Next(min, max);
        return new MatematyczneWyzwanie(
            $"{a} × {b} = ?",
            answer => answer == a * b);
    }

    public static MatematyczneWyzwanie CreateDivisionChallenge(Difficulty difficulty = Difficulty.Easy)
    {
        var (min, max) = difficulty switch
        {
            Difficulty.Easy => (2, 10),
            Difficulty.Normal => (11, 20),
            Difficulty.Hard => (21, 50),
            Difficulty.Insane => (51, 100),
            _ => (2, 10)
        };

        var a = Random.Shared.Next(min, max);
        var b = Random.Shared.Next(min, max);
        return new MatematyczneWyzwanie(
            $"{a * b} ÷ {b} = ?",
            answer => answer == a);
    }

    public override bool Validate(string response)
    {
        if (!double.TryParse(response, out var answer))
            return false;

        return _validator(answer);
    }
}
