using System;
using Minesweeper;
using Minesweeper.Tests.TestHelpers;

namespace Minesweeper.Tests;

public class TestUserInput
{
    [Fact]
    public void GetUserInput_ValidIntegerInput_ReturnsValue()
    {
        // Arrange
        using var console = new ConsoleIO("15");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(15, result);
        Assert.Contains("Enter value: ", console.Output);
    }
    
    [Fact]
    public void GetUserInput_EmptyInput_ReturnsDefaultValue()
    {
        // Arrange
        using var console = new ConsoleIO("");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(10, result);
        Assert.Contains("Enter value: ", console.Output);
    }
    
    [Fact]
    public void GetUserInput_ValidDoubleInput_ReturnsValue()
    {
        // Arrange
        using var console = new ConsoleIO("0.25");
        
        // Act
        var result = Program.GetUserInput("Enter density: ", 0.1, 0.5, 0.1);
        
        // Assert
        Assert.Equal(0.25, result);
        Assert.Contains("Enter density: ", console.Output);
    }
    
    [Fact]
    public void GetUserInput_InputBelowMinimum_ThrowsAndRetryWithValidInput()
    {
        // Arrange
        using var console = new ConsoleIO("3", "8");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(8, result);
        Assert.Contains("Invalid input:", console.Output);
        Assert.Contains("Input must be between 5 and 20", console.Output);
    }
    
    [Fact]
    public void GetUserInput_InputAboveMaximum_ThrowsAndRetryWithValidInput()
    {
        // Arrange
        using var console = new ConsoleIO("25", "15");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(15, result);
        Assert.Contains("Invalid input:", console.Output);
        Assert.Contains("Input must be between 5 and 20", console.Output);
    }
    
    [Fact]
    public void GetUserInput_NonParseableInput_ThrowsAndRetryWithValidInput()
    {
        // Arrange
        using var console = new ConsoleIO("abc", "15");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(15, result);
        Assert.Contains("Invalid input:", console.Output);
    }
    
    [Fact]
    public void GetUserInput_MultipleInvalidInputs_EventuallyUsesValidInput()
    {
        // Arrange
        using var console = new ConsoleIO("abc", "2", "30", "15");
        
        // Act
        var result = Program.GetUserInput("Enter value: ", 5, 20, 10);
        
        // Assert
        Assert.Equal(15, result);
        Assert.Contains("Invalid input:", console.Output);
    }
    
    [Fact]
    public void GetUserInput_DifferentGenericTypes_HandledCorrectly()
    {
        // Test with string type (min and max won't be used for comparison)
        using (var console = new ConsoleIO("test"))
        {
            var stringResult = Program.GetUserInput("Enter string: ", "a", "z", "default");
            Assert.Equal("test", stringResult);
        }
        
        // Test with int
        using (var console = new ConsoleIO("15"))
        {
            var intResult = Program.GetUserInput("Enter int: ", 1, 100, 50);
            Assert.Equal(15, intResult);
        }
        
        // Test with double
        using (var console = new ConsoleIO("1.5"))
        {
            var doubleResult = Program.GetUserInput("Enter double: ", 0.5, 2.5, 1.0);
            Assert.Equal(1.5, doubleResult);
        }
    }
}
