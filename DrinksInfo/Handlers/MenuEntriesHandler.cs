﻿using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Interfaces.View.Factory;
using Spectre.Console;

namespace DrinksInfo.Handlers;

/// <summary>
/// Represents a handler for menu entries.
/// </summary>
/// <typeparam name="TMenu">The type of menu entries.</typeparam>
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

    /// <summary>
    /// Represents a method for handling the menu entries.
    /// </summary>
    public void HandleMenu()
    {
        var userChoice = HandleUserChoice(_menuEntries);
        _menuCommandFactory.GetCommand(userChoice).Execute();
    }

    private static TMenu HandleUserChoice(SelectionPrompt<string> menuEntries) =>
        AnsiConsole.Prompt(menuEntries).GetValueFromDisplayName<TMenu>();
}