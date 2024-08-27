using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;

namespace DrinksInfo.View.Commands.FilterMenuCommands;

internal class FilterByGlassCommand : BaseFilterCommand
{
    public FilterByGlassCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Drinks FetchQuery(string input) =>
        HttpManager.GetResponse(ApiEndpoints.Filter.ByGlass, input);

    private protected override string[] FetchPropertyArray(Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.DrinkGlassType);

    private protected override Drinks GetListOfFilters() => 
        HttpManager.GetResponse(ApiEndpoints.Lists.Glasses);
}