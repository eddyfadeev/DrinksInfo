﻿using System.Windows.Input;
using DrinksInfo.Enums;
using DrinksInfo.Interfaces.View.Factory;

namespace DrinksInfo.View.Factory;

/// <inheritdoc cref="IMenuCommandFactory{TMenu}"/>
internal class MenuCommandFactory<TMenu> : IMenuCommandFactory<TMenu> where TMenu : Enum
{
    private readonly Dictionary<TMenu, Func<ICommand>> _menuCommands;
    
    public MenuCommandFactory(IMenuEntriesInitializer<TMenu> menuEntriesInitializer)
    {
        _menuCommands = menuEntriesInitializer.InitializeMenuEntries();
    }
    
    /// <inheritdoc cref="IMenuCommandFactory{TMenu}.GetCommand"/>
    public ICommand GetCommand(TMenu menuEntry)
    {
        if (_menuCommands.TryGetValue(menuEntry, out var menuCommand))
        {
            return menuCommand();
        }
        
        throw new InvalidOperationException($"Menu command not found for the { menuCommand }.");
    }
}