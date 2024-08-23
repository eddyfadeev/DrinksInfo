﻿using System.Windows.Input;

namespace DrinksInfo.Interfaces.View.Factory;

/// Represents a factory for creating menu commands.
/// This interface allows the creation of menu commands based on a specified menu entry.
/// <typeparam name="TMenu">
/// The type of the menu entries, which must be an enum
/// </typeparam> 
internal interface IMenuCommandFactory<in TMenu> where TMenu : Enum
{
    
    /// <summary>
    /// Retrieves the command for the specified menu entry.
    /// </summary>
    /// <param name="menuEntry">The enum entry.</param>
    /// <returns>The command associated with the enum entry.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the menu command is not found for the specified menu entry.</exception>
    ICommand GetCommand(TMenu menuEntry);
}