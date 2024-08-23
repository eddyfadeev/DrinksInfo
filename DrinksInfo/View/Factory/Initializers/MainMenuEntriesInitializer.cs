using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.MainMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class MainMenuEntriesInitializer : IMenuEntriesInitializer<MainMenuEntries> 
{
    private readonly IMenuEntriesHandler<SearchMenuEntries> _searchMenuEntriesHandler;
    private readonly IMenuEntriesHandler<FilterMenuEntries> _filterMenuEntriesHandler;
    
    public MainMenuEntriesInitializer(
        IMenuEntriesHandler<SearchMenuEntries> searchMenuEntriesHandler, 
        IMenuEntriesHandler<FilterMenuEntries> filterMenuEntriesHandler
        )
    {
        _searchMenuEntriesHandler = searchMenuEntriesHandler;
        _filterMenuEntriesHandler = filterMenuEntriesHandler;
    }
    
    public Dictionary<MainMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { MainMenuEntries.GetRandom, () => new GetRandomDrinkCommand() },
            { MainMenuEntries.SearchMenu, () => new OpenSearchCommand(_searchMenuEntriesHandler) }, 
            { MainMenuEntries.FiltersMenu, () => new OpenFilterByCommand(_filterMenuEntriesHandler) },
            { MainMenuEntries.Exit, () => throw new ExitApplicationException()}
        };
}

