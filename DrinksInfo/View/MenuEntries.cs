using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.View;
using Spectre.Console;

namespace DrinksInfo.View;

internal class MenuEntries<TMenu>  : IMenuEntries<TMenu>
    where TMenu : Enum
{
    public SelectionPrompt<string> GetMenuEntries() =>
        new SelectionPrompt<string>()
            .Title("Select an option:")
            .AddChoices(EnumExtensions.GetDisplayNames<TMenu>());
}