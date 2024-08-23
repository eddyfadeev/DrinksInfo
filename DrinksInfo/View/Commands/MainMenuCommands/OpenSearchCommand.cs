using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Interfaces.Handlers;

namespace DrinksInfo.View.Commands.MainMenuCommands;

internal class OpenSearchCommand : ICommand
{
    private readonly IMenuEntriesHandler<SearchMenuEntries> _searchMenuEntriesHandler;
    
    public OpenSearchCommand(IMenuEntriesHandler<SearchMenuEntries> searchMenuEntriesHandler)
    {
        _searchMenuEntriesHandler = searchMenuEntriesHandler;
    }
    
    public void Execute()
    {
        _searchMenuEntriesHandler.HandleMenu();
    }
}