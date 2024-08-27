using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.View.Commands.FilterMenuCommands;

internal abstract class BaseFilterCommand : BaseCommand<string>
{
    protected BaseFilterCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    public override void Execute()
    {
        while (true)
        {
            var userChoice = GetUserFilterChoice();
            if (userChoice == null)
            {
                break;
            }
            
            var drinksCategories = FetchQuery(userChoice);
            var drinkChoice = GetUserDrinkChoice(drinksCategories);
            
            if (drinkChoice == null)
            {
                continue;
            }
            
            var drink = FetchDrink(drinkChoice);
            DisplayDrinkDetail(drink);
            break;
        }
    }
    
    private protected abstract Drinks GetListOfFilters();
    
    private void DisplayDrinkDetail(Drink drink)
    {
        var table = TableConstructor.CreateDrinkTable(drink);

        AnsiConsole.Write(table);
    }

    private Drink FetchDrink(string drinkName) =>
        HttpManager
            .GetResponse(ApiEndpoints.Search.CocktailByName, drinkName).DrinksList[0];

    
    private static string? GetUserDrinkChoice(Drinks drinks)
    {
        var drinkNames = drinks.GetPropertyArray(d => d.DrinkName);
        
        return GetUserChoice(drinkNames, "No drinks found!");
    }
    
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
    
    private string? GetUserFilterChoice()
    {
        var listOfFilters = GetListOfFilters();
        var availableFilters = FetchPropertyArray(listOfFilters);
            
        if (availableFilters.Length == 0)
        {
            HandleNoResults("No categories found!");
            return null;
        }
            
        var userChoice = DynamicEntriesHandler.HandleDynamicEntries(availableFilters);
            
        return IsBackOption(userChoice) ? null : userChoice;
    }
}