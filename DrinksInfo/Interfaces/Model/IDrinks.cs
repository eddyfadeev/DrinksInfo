using DrinksInfo.Models;

namespace DrinksInfo.Interfaces.Model;

internal interface IDrinks
{
    List<Drink> DrinksList { get; set; }
    public Drink this[int index] { get; }
    public int Count { get; }
}