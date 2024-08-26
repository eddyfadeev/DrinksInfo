using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.Interfaces.View;

internal interface ITableConstructor
{
    Table CreateDrinkTable(Drink drink);
}