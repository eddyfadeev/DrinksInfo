using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;


namespace DrinksInfo.View.Commands.FilterMenuCommands;

internal class FilterByIngredientCommand : BaseFilterCommand
{
    public FilterByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByIngredient, input);

    private protected override string[] FetchPropertyArray(Drinks drinks) =>
        drinks.DrinksList
            .SelectMany(drink => drink.Ingredients ?? Array.Empty<string>())
            .ToArray();

    private protected override Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.Ingredients);
}