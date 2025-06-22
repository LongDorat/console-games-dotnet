using System.Text;

namespace Minesweeper.Tests.TestHelpers;

/// <summary>
/// Helper class for testing console input and output
/// </summary>
public class ConsoleIO : IDisposable
{
    private readonly StringReader _inputReader;
    private readonly StringWriter _outputWriter;
    private readonly TextReader _originalIn;
    private readonly TextWriter _originalOut;

    /// <summary>
    /// Gets the captured console output
    /// </summary>
    public string Output => _outputWriter.ToString();

    /// <summary>
    /// Creates a new instance of ConsoleIO with the specified input
    /// </summary>
    /// <param name="input">Input string(s) to be returned by Console.ReadLine()</param>
    public ConsoleIO(params string[] input)
    {
        _originalIn = Console.In;
        _originalOut = Console.Out;

        _inputReader = new StringReader(string.Join(Environment.NewLine, input));
        _outputWriter = new StringWriter();

        Console.SetIn(_inputReader);
        Console.SetOut(_outputWriter);
    }

    public void Dispose()
    {
        Console.SetIn(_originalIn);
        Console.SetOut(_originalOut);
        _inputReader.Dispose();
        _outputWriter.Dispose();
    }
}