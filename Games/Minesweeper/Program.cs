namespace Minesweeper;

public class Program
{
    static void Main(string[] args)
    {
        Configurations.Height = GetUserInput("Enter board height 5 - 20 (default 10): ", 5, 20, 10);
        Configurations.Width = GetUserInput("Enter board width 5 - 20 (default 10): ", 5, 20, 10);

        double minesDensity = GetUserInput("Enter mines density 10% - 50% (0.1 for 10%): ", 0.1, 0.5, 0.1);
        Configurations.SetMines(minesDensity);

        Game.Start();
    }

    public static T? GetUserInput<T>(
        string prompt,
        T MINVALUE,
        T MAXVALUE,
        T defaultValue = default)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input) && !EqualityComparer<T>.Default.Equals(defaultValue, default))
        {
            return defaultValue;
        }

        try
        {
            var result = (T?)Convert.ChangeType(input, typeof(T));
            if (result is null
                || Comparer<T>.Default.Compare(result, MINVALUE) < 0
                || Comparer<T>.Default.Compare(result, MAXVALUE) > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(prompt), $"Input must be between {MINVALUE} and {MAXVALUE}.");
            }

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid input: {ex.Message}. Please try again.");
            return GetUserInput(prompt, MINVALUE, MAXVALUE, defaultValue);
        }
    }
}
