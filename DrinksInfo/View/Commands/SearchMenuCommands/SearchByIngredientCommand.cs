using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal class SearchByIngredientCommand : BaseSearchCommand
{
    public SearchByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override string UserPrompt => "Enter the letter(s) or the name of the ingredient : ";

    private protected override Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Search.ByIngredientName, input);
}