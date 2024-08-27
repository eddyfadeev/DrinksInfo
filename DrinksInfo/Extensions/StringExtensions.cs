﻿using DrinksInfo.Models;
using Newtonsoft.Json;

namespace DrinksInfo.Extensions;

/// <summary>
/// Contains a string extension method to convert a JSON string to a Drinks object.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Extension method for converting a JSON string to a list of drinks.
    /// </summary>
    /// <param name="jsonString">The JSON string representing a list of drinks.</param>
    /// <returns>A Drinks object containing the list of drinks parsed from the JSON string. If the JSON string is null or empty, an empty Drinks object is returned.</returns>
    public static Drinks ConvertToDrinksList(this string jsonSting) =>
        JsonConvert.DeserializeObject<Drinks>(jsonSting) ?? new Drinks();
}