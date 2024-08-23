using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Interfaces.Handlers;

namespace DrinksInfo.View.Commands.MainMenuCommands;

internal class OpenFilterByCommand : ICommand
{
    private readonly IMenuEntriesHandler<FilterMenuEntries> _filterMenuEntriesHandler;
    
    public OpenFilterByCommand(IMenuEntriesHandler<FilterMenuEntries> filterMenuEntriesHandler)
    {
        _filterMenuEntriesHandler = filterMenuEntriesHandler;
    }
    
    public void Execute()
    {
        _filterMenuEntriesHandler.HandleMenu();
    }
}