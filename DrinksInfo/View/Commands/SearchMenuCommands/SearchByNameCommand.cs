using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using DrinksInfo.Services;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal class SearchByNameCommand : BaseSearchCommand
{
    private const string UserPrompt = "Enter the letter(s) or the name of the cocktail : ";
    public SearchByNameCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    private protected override string GetUserInput() => 
        UserChoiceService.GetUserInput<string>(UserPrompt);

    private protected override Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Search.CocktailByName, input);
}