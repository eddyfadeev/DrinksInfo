namespace DrinksInfo.Models;

internal class ApiConfig
{
    public string? BaseUrl { get; set; }
    public string? RandomCocktail { get; set; }
    public Dictionary<string, string> Lists { get; set; } = new();
    public Dictionary<string, string> Search { get; set; } = new();
    public Dictionary<string, string> Lookup { get; set; } = new();
    public Dictionary<string, string> Filter { get; set; } = new();
}