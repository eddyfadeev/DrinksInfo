using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;

namespace DrinksInfo.View.Commands.FilterMenuCommands;

internal abstract class BaseFilterCommand : BaseCommand<string>
{
    protected BaseFilterCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    public override void Execute()
    {
        var userChoice = GetUserFilterChoice();
        if (userChoice == null)
        {
            return;
        }
        
        var drinksCategories = FetchQuery(userChoice);
        
        var drinkChoice = GetUserDrinkChoice(drinksCategories);
        if (drinkChoice == null)
        {
            return;
        }
        
        var drink = FetchDrink(drinkChoice);
        DisplayDrinkDetail(drink);
    }
    
    private protected abstract Drinks GetListOfFilters();
    
    private protected abstract string[] FetchPropertyArray(Drinks drinks);
    
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