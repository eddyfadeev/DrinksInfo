using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace DrinksInfo;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = ServicesConfigurator.ServiceCollection;
        var serviceProvider = services.BuildServiceProvider();
        
        var menuEntriesHandler = serviceProvider.GetRequiredService<IMenuEntriesHandler<MainMenuEntries>>();
        
        while (true)
        {
            Console.Clear();
            try
            {
                menuEntriesHandler.HandleMenu();
            }
            catch (ReturnToPreviousMenuException)
            {
                // return to the previous menu
            }
            catch (ExitApplicationException ex)
            {
                AnsiConsole.MarkupLine($"[white]{ ex.Message }[/]");
                break;
            }
            
            WaitForEnter();
        }
    }
    
    private static void WaitForEnter()
    {
        AnsiConsole.MarkupLine("[green]Press Enter to continue...[/]");
        do
        {
            var keyPress = Console.ReadKey(true);
            if (keyPress.Key == ConsoleKey.Enter)
            {
                break;
            }
        } while (true);
    }
}
