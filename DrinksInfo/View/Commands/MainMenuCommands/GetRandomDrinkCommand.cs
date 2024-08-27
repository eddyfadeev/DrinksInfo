using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.View.Commands.MainMenuCommands;

internal sealed class GetRandomDrinkCommand : ICommand
{
    private readonly IHttpManger _httpManger;
    private readonly ITableConstructor _tableConstructor;
    public GetRandomDrinkCommand(IHttpManger httpManger, ITableConstructor tableConstructor)
    {
        _httpManger = httpManger;
        _tableConstructor = tableConstructor;
    }
    
    public void Execute()
    {
        var drinks = _httpManger.GetResponse(ApiEndpoints.Random.RandomCocktail);

        var drinkTable = _tableConstructor.CreateDrinkTable(drinks[0]);
        
        AnsiConsole.Write(drinkTable);
        
        HelpService.WaitForEnter();
    }
}