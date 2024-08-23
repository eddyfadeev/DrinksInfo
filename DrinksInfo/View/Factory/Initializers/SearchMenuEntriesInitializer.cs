using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.SearchMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class SearchMenuEntriesInitializer : IMenuEntriesInitializer<SearchMenuEntries>
{
    public Dictionary<SearchMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { SearchMenuEntries.SearchByFirstLetter, () => new SearchByFirstLetterCommand() },
            { SearchMenuEntries.SearchByName, () => new SearchByNameCommand() },
            { SearchMenuEntries.SearchByIngredient, () => new SearchByIngredientCommand() },
            { SearchMenuEntries.SearchByGlassType, () => new SearchByIngredientCommand() },
            { SearchMenuEntries.SearchByCategory, () => new SearchByCategoryCommand() },
            { SearchMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}