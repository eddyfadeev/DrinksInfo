using System.Windows.Input;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.MainMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class MainMenuEntriesInitializer : IMenuEntriesInitializer<MainMenuEntries> 
{
    public Dictionary<MainMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { MainMenuEntries.GetRandom, () => new GetRandomDrinkCommand() },
            { MainMenuEntries.SearchMenu, () => new OpenSearchCommand() }, 
            { MainMenuEntries.FiltersMenu, () => new OpenFilterByCommand() },
            { MainMenuEntries.Exit, () => throw new ExitApplicationException()}
        };
}