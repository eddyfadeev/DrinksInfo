using System.Net.Http.Headers;
using System.Text;
using DrinksInfo.Enums;
using DrinksInfo.Exceptions;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Models;
using DrinksInfo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Spectre.Console;

namespace DrinksInfo;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = ServicesConfigurator.ServiceCollection;
        var serviceProvider = services.BuildServiceProvider();
        
        var menuEntriesHandler = serviceProvider.GetRequiredService<IMenuEntriesHandler<MainMenuEntries>>();
        var apiConfig = serviceProvider.GetRequiredService<IOptions<ApiConfig>>();
        Console.WriteLine($"Base API URL: {apiConfig.Value.BaseUrl}");
        
        
        while (true)
        {
            try
            {
                menuEntriesHandler.HandleMenu();
            }
            catch (ReturnToPreviousMenuException)
            {
                // return to the previous menu
            }
            catch (ExitApplicationException ex)
            {
                AnsiConsole.MarkupLine($"[white]{ ex.Message }[/]");
                break;
            }
        }
        
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
