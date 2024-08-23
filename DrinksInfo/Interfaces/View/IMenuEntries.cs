using Spectre.Console;

namespace DrinksInfo.Interfaces.View;

internal interface IMenuEntries<TMenu> 
    where TMenu : Enum
{
    SelectionPrompt<string> GetMenuEntries();
}