using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Interfaces.View.Factory;
using Spectre.Console;

namespace DrinksInfo.Handlers;

internal class MenuEntriesHandler<TMenu> : IMenuEntriesHandler<TMenu>
    where TMenu : Enum
{
    private readonly IMenuCommandFactory<TMenu> _menuCommandFactory;
    private readonly SelectionPrompt<string> _menuEntries;
    public MenuEntriesHandler(IMenuEntries<TMenu> menuEntries, IMenuCommandFactory<TMenu> menuCommandFactory)
    {
        _menuEntries = menuEntries.GetMenuEntries();
        _menuCommandFactory = menuCommandFactory;
    }
    
    public void HandleMenu()
    {
        var userChoice = HandleUserChoice(_menuEntries);
        _menuCommandFactory.GetCommand(userChoice).Execute(null);
    }

    private static TMenu HandleUserChoice(SelectionPrompt<string> menuEntries) =>
        AnsiConsole.Prompt(menuEntries).GetValueFromDisplayName<TMenu>();
}