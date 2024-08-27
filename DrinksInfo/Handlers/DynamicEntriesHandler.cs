using Spectre.Console;

namespace DrinksInfo.Handlers;

internal static class DynamicEntriesHandler 
{
    public static string HandleDynamicEntries(string[] dynamicEntries)
    {
        var menuEntries = new SelectionPrompt<string>();
        menuEntries.AddChoices(dynamicEntries);
        menuEntries.AddChoice("Back");
        
        return AnsiConsole.Prompt(menuEntries);
    }
}