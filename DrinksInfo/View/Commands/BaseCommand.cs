using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.View.Commands;

internal abstract class BaseCommand<T> : ICommand
{
    private readonly ITableConstructor _tableConstructor;
    
    private protected readonly IHttpManger HttpManager;
    
    protected BaseCommand(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        HttpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public abstract void Execute();
    
    private protected abstract Drinks FetchQuery(T input);
    
    private protected Drink FetchDrink(string drinkName) =>
        HttpManager
            .GetResponse(ApiEndpoints.Search.CocktailByName, drinkName).DrinksList[0];
    
    private protected void DisplayDrinkDetail(Drink drink)
    {
        var table = _tableConstructor.CreateDrinkTable(drink);

        AnsiConsole.Write(table);
        HelpService.WaitForEnter();
    }
    
    private protected static string? GetUserDrinkChoice(Drinks drinks)
    {
        var drinkNames = FetchDrinkNames(drinks);
        
        return GetUserChoice(drinkNames, Messages.NoDrinksFound);
    }
    
    private protected static void HandleNoResults(string message) =>
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    
    private protected static bool IsBackOption(string userChoice) =>
        userChoice == Messages.BackOption;
    
    private static string? GetUserChoice(string[] options, string emptyMessage)
    {
        if (options.Length == 0)
        {
            HandleNoResults(emptyMessage);
            return null;
        }

        var userChoice = DynamicEntriesHandler.HandleDynamicEntries(options);
        return IsBackOption(userChoice) ? null : userChoice;
    }
    
    private static string[] FetchDrinkNames(Drinks drinks) =>
        drinks.GetPropertyArray(d => d.DrinkName);
}