using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.View.Commands;

internal abstract class BaseCommand<T> : ICommand
{
    private const string BackOption = "Back";
    
    private protected readonly ITableConstructor TableConstructor;
    
    private protected readonly IHttpManger HttpManager;
    
    protected BaseCommand(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        HttpManager = httpManager;
        TableConstructor = tableConstructor;
    }
    
    public abstract void Execute();
    
    private protected abstract Drinks FetchQuery(T input);
    
    private protected abstract string[] FetchPropertyArray(Drinks drinks);
    
    private protected Drinks FetchDrinksByFilter(ApiEndpoints.Filter filter, string input) =>
        HttpManager.GetResponse(filter, input);
    
    private protected static void HandleNoResults(string message) =>
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    
    private protected static bool IsBackOption(string userChoice) =>
        userChoice == BackOption;
}