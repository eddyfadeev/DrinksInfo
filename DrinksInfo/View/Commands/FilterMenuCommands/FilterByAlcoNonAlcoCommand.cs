using DrinksInfo.Enums;
using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;

namespace DrinksInfo.View.Commands.FilterMenuCommands;

internal class FilterByAlcoNonAlcoCommand : BaseFilterCommand
{
    public FilterByAlcoNonAlcoCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    private protected override Drinks FetchQuery(string input) => 
        HttpManager.GetResponse(ApiEndpoints.Filter.ByAlcoholic, input);

    private protected override string[] FetchPropertyArray(Drinks drinks) =>
        drinks.GetPropertyArray(cat => cat.IsAlcoholic);

    private protected override Drinks GetListOfFilters() =>
        HttpManager.GetResponse(ApiEndpoints.Lists.AlcoholicOptions);
}