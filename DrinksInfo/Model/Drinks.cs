﻿using DrinksInfo.Interfaces.Model;
using Newtonsoft.Json;

namespace DrinksInfo.Model;

internal class Drinks: IDrinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; } = new();

    public Drink this[int index]
    {
        get
        {
            if (index < 0 || index >= DrinksList.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), 
                    index,
                    $"Index is out of range. Index should be between 0 and {DrinksList.Count - 1}."
                );
            }
            
            return DrinksList[index];
        }
    }

    public int Count => DrinksList.Count;
}