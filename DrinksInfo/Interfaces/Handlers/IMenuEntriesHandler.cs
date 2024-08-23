namespace DrinksInfo.Interfaces.Handlers;

internal interface IMenuEntriesHandler<out TMenu>
    where TMenu : Enum
{
    void HandleMenu();
}