using DrinksInfo.Models;
using Newtonsoft.Json;

namespace DrinksInfo.Extensions;

internal static class StringExtensions
{
    public static Drinks ConvertToDrinksList(this string jsonSting) =>
        JsonConvert.DeserializeObject<Drinks>(jsonSting) ?? new Drinks();
}