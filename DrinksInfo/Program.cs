using System.Net.Http.Headers;
using System.Text;
using DrinksInfo.Model;
using Newtonsoft.Json;

namespace DrinksInfo;

class Program
{
    static void Main(string[] args)
    {
        using HttpClient client = new();
        
        var savePath = Path.Combine(Environment.CurrentDirectory, "drinks.json");
        
        client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var response = client.GetAsync("search.php?s=margarita").Result;

        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        
        var content = response.Content.ReadAsStringAsync().Result;
        var drinks = JsonConvert.DeserializeObject<Drinks>(content);
        var jsonContent = JsonConvert.SerializeObject(drinks, Formatting.Indented);
        File.WriteAllText(savePath, jsonContent, Encoding.Unicode);
            
        foreach (var drink in drinks.DrinksList)
        {
            Console.WriteLine(drink.DrinkId);
            Console.WriteLine(drink.DrinkName);
            Console.WriteLine(drink.Measures?[0]);
        }
    }

    
}
