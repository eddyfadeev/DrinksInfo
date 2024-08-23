using DrinksInfo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DrinksInfo.Mappers;

internal class DrinkMapper : JsonConverter<Drink>
    {
        public override Drink ReadJson(JsonReader reader, Type objectType, Drink? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            var drink = new Drink
            {
                DrinkId = jObject["idDrink"]?.ToString(),
                DrinkName = jObject["strDrink"]?.ToString(),
                DrinkTags = jObject["strTags"]?.ToString(),
                DrinkCategory = jObject["strCategory"]?.ToString(),
                IsAlcoholic = jObject["strAlcoholic"]?.ToString(),
                DrinkGlassType = jObject["strGlass"]?.ToString(),
                DrinkInstructions = jObject["strInstructions"]?.ToString(),
                DrinkImage = jObject["strDrinkThumb"]?.ToString()
            };

            drink.Ingredients = jObject.Properties()
                .Where(p => p.Name.StartsWith("strIngredient") && !string.IsNullOrWhiteSpace(p.Value.ToString()))
                .Select(p => p.Value.ToString())
                .ToArray();

            drink.Measures = jObject.Properties()
                .Where(p => p.Name.StartsWith("strMeasure") && !string.IsNullOrWhiteSpace(p.Value.ToString()))
                .Select(p => p.Value.ToString())
                .ToArray();
            
            return drink;
        }
        
        public override void WriteJson(JsonWriter writer, Drink? value, JsonSerializer serializer)
        {
            JObject jObject = new JObject
            {
                { "idDrink", value?.DrinkId },
                { "strDrink", value?.DrinkName },
                { "strTags", value?.DrinkTags },
                { "strCategory", value?.DrinkCategory },
                { "strAlcoholic", value?.IsAlcoholic },
                { "strGlass", value?.DrinkGlassType },
                { "strInstructions", value?.DrinkInstructions },
                { "strDrinkThumb", value?.DrinkImage }
            };
            
            if (value?.Ingredients != null)
            {
                for (int i = 0; i < value.Ingredients.Length; i++)
                {
                    string ingredientKey = $"strIngredient{i + 1}";
                    jObject.Add(ingredientKey, value.Ingredients[i]);
                }
            }

            if (value?.Measures != null)
            {
                for (int i = 0; i < value.Measures.Length; i++)
                {
                    string measureKey = $"strMeasure{i + 1}";
                    jObject.Add(measureKey, value.Measures[i]);
                }
            }
            
            jObject.WriteTo(writer);
        }
    }