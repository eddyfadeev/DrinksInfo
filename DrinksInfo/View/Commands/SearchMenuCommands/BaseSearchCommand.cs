using DrinksInfo.Extensions;
using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal abstract class BaseSearchCommand : BaseCommand<string>
{
    protected BaseSearchCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    public override void Execute()
    {
        while (true)
        {
            var userInput = GetUserInput();
            var drinks = FetchQuery(userInput);

            var propertyArray = FetchPropertyArray(drinks);

            if (propertyArray.Length == 0)
            {
                AnsiConsole.MarkupLine(Messages.NoDrinksFound);
                continue;
            }

            var userChoice = DynamicEntriesHandler.HandleDynamicEntries(propertyArray);

            if (IsBackOption(userChoice))
            {
                continue;
            }
            
            var drink = FetchDrink(userChoice);

            DisplayDrinkDetail(drink);
            break;
        }
    }
    
    private protected abstract string GetUserInput(); 
    
    private protected override string[] FetchPropertyArray(Drinks drinks) =>
        drinks.GetPropertyArray(d => d.DrinkName);
}