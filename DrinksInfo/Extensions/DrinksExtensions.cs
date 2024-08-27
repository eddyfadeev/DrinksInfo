using DrinksInfo.Models;

namespace DrinksInfo.Extensions;

internal static class DrinksExtensions
{
    public static string[] GetPropertyArray(this Drinks drinks, Func<Drink, string> selector)
    {
        return drinks?.DrinksList == null ? 
            Array.Empty<string>() : 
            drinks.DrinksList.Select(selector).ToArray();
    }
}