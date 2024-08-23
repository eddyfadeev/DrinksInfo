using System.Net.Http.Headers;
using System.Text;
using DrinksInfo.Enums;
using DrinksInfo.Model;
using DrinksInfo.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DrinksInfo;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = ServicesConfigurator.ServiceCollection;
        var serviceProvider = services.BuildServiceProvider();
        
        var menuEntriesHandler = serviceProvider.GetRequiredService<IMenuEntriesHandler<MainMenuEntries>>();
        menuEntriesHandler.HandleMenu();
        
        // using HttpClient client = new();
        //
        // var savePath = Path.Combine(Environment.CurrentDirectory, "drinks.json");
        //
        // client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //
        // var response = client.GetAsync("search.php?s=margarita").Result;
        //
        // if (!response.IsSuccessStatusCode)
        // {
        //     return;
        // }
        //
        // var content = response.Content.ReadAsStringAsync().Result;
        // var drinks = JsonConvert.DeserializeObject<Drinks>(content);
        // var jsonContent = JsonConvert.SerializeObject(drinks, Formatting.Indented);
        // File.WriteAllText(savePath, jsonContent, Encoding.Unicode);
        //     
        // foreach (var drink in drinks.DrinksList)
        // {
        //     Console.WriteLine(drink.DrinkId);
        //     Console.WriteLine(drink.DrinkName);
        //     Console.WriteLine(drink.Measures?[0]);
        // }
    }

    
}
