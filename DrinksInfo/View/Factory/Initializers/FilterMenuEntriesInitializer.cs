using DrinksInfo.Interfaces.View;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View.Commands.FilterMenuCommands;

namespace DrinksInfo.View.Factory.Initializers;

internal class FilterMenuEntriesInitializer : IMenuEntriesInitializer<FilterMenuEntries>
{
    public Dictionary<FilterMenuEntries, Func<ICommand>> InitializeMenuEntries() =>
        new()
        {
            { FilterMenuEntries.FilterByCategory, () => new FilterByCategoryCommand() },
            { FilterMenuEntries.FilterByAlcoNonAlco, () => new FilterByAlcoNonAlcoCommand() },
            { FilterMenuEntries.FilterByGlass, () => new FilterByGlassCommand() },
            { FilterMenuEntries.FilterByIngredient, () => new FilterByIngredientCommand() },
            { FilterMenuEntries.Back, () => throw new ReturnToPreviousMenuException() }
        };
}