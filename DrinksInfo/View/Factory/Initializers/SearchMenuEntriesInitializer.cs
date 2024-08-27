using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.SearchMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class SearchMenuEntriesInitializer : IMenuEntriesInitializer<SearchMenuEntries>
{
    private readonly IHttpManger _httpManager;
    private readonly ITableConstructor _tableConstructor;
    
    public SearchMenuEntriesInitializer(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        _httpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public Dictionary<SearchMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { SearchMenuEntries.SearchByFirstLetter, () => new SearchByFirstLetterCommand(_httpManager, _tableConstructor) },
            { SearchMenuEntries.SearchByName, () => new SearchByNameCommand() },
            { SearchMenuEntries.SearchByIngredient, () => new SearchByIngredientCommand(_httpManager, _tableConstructor) },
            { SearchMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}