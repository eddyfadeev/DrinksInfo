using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal class SearchByFirstLetterCommand : BaseSearchCommand<char>
{
    public SearchByFirstLetterCommand(IHttpManger httpManager, ITableConstructor tableConstructor) :
        base(httpManager, tableConstructor)
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
                AnsiConsole.MarkupLine("[red]No drinks found![/]");
                continue;
            }

            var userChoice = DynamicEntriesHandler.HandleDynamicEntries(propertyArray);

            if (IsBackOption(userChoice))
            {
                continue;
            }

            DisplayDrinksDetail(drinks, userChoice);
            break;
        }
    }
    
    private protected override Drinks FetchQuery(char input) => 
        HttpManager.GetResponse(ApiEndpoints.Search.CocktailByFirstLetter, input.ToString());

    private protected override string[] FetchPropertyArray(Drinks drinks) => 
        drinks.GetPropertyArray(d => d.DrinkName);
}