using Spectre.Console;

namespace DrinksInfo.Services;

public static class UserChoiceService
{
    public static T GetUserInput<T>(string message)
    {
        var userInput = AnsiConsole.Ask<T>(message);
        
        return userInput;
    }
}