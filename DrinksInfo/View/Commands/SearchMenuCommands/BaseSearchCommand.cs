using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal abstract class BaseSearchCommand<T> : BaseCommand<T>
{
    protected BaseSearchCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected void DisplayDrinksDetail(Drinks drinks, string drinkName)
    {
        var drink = drinks.DrinksList.First(d => d.DrinkName == drinkName);
        var table = TableConstructor.CreateDrinkTable(drink);

        AnsiConsole.Write(table);
    }

    // private protected Drinks FetchDrinks(string drinkName) =>
    //     HttpManager
    //         .GetResponse(ApiEndpoints.Search.CocktailByName, drinkName);
    
    private protected static T GetUserInput() => 
        UserChoiceService.GetUserInput<T>(
            "Enter the search query: ");
    
    // private protected static string? GetUserDrinkChoice(Drinks drinks)
    // {
    //     var drinkNames = drinks.GetPropertyArray(d => d.DrinkName);
    //         
    //     if (drinkNames.Length == 0)
    //     {
    //         HandleNoResults("No drinks found!");
    //         return null;
    //     }
    //         
    //     var userChoice = DynamicEntriesHandler.HandleDynamicEntries(drinkNames);
    //         
    //     return IsBackOption(userChoice) ? null : userChoice;
    // }
}