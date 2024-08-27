using DrinksInfo.Models;

namespace DrinksInfo.Interfaces.Model;

/// <summary>
/// Represents an interface for a collection of drinks.
/// </summary>
internal interface IDrinks
{
    List<Drink> DrinksList { get; set; }
    public Drink this[int index] { get; }
}