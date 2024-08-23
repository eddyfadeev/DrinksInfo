using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.Models;
using DrinksInfo.View.Commands.MainMenuCommands;
using Microsoft.Extensions.Options;

namespace DrinksInfo.View.Factory.Initializers;

internal class MainMenuEntriesInitializer : IMenuEntriesInitializer<MainMenuEntries> 
{
    private readonly IMenuEntriesHandler<SearchMenuEntries> _searchMenuEntriesHandler;
    private readonly IMenuEntriesHandler<FilterMenuEntries> _filterMenuEntriesHandler;
    private readonly IOptions<ApiConfig> _apiConfig;
    
    public MainMenuEntriesInitializer(
        IMenuEntriesHandler<SearchMenuEntries> searchMenuEntriesHandler, 
        IMenuEntriesHandler<FilterMenuEntries> filterMenuEntriesHandler,
        IOptions<ApiConfig> apiConfig
        )
    {
        _searchMenuEntriesHandler = searchMenuEntriesHandler;
        _filterMenuEntriesHandler = filterMenuEntriesHandler;
        _apiConfig = apiConfig;
    }
    
    public Dictionary<MainMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { MainMenuEntries.GetRandom, () => new GetRandomDrinkCommand(_apiConfig) },
            { MainMenuEntries.SearchMenu, () => new OpenSearchCommand(_searchMenuEntriesHandler) }, 
            { MainMenuEntries.FiltersMenu, () => new OpenFilterByCommand(_filterMenuEntriesHandler) },
            { MainMenuEntries.Exit, () => throw new ExitApplicationException()}
        };
}

