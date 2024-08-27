using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.FilterMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class FilterMenuEntriesInitializer : IMenuEntriesInitializer<FilterMenuEntries>
{
    private readonly IHttpManger _httpManager;
    private readonly ITableConstructor _tableConstructor;
    
    public FilterMenuEntriesInitializer(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        _httpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public Dictionary<FilterMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { FilterMenuEntries.FilterByCategory, () => new FilterByCategoryCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByAlcoNonAlco, () => new FilterByAlcoNonAlcoCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByGlass, () => new FilterByGlassCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.FilterByIngredient, () => new FilterByIngredientCommand(_httpManager, _tableConstructor) },
            { FilterMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}