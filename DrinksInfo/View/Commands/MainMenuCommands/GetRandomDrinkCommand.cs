using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using DrinksInfo.Resolvers;
using Microsoft.Extensions.Options;

namespace DrinksInfo.View.Commands.MainMenuCommands;

internal sealed class GetRandomDrinkCommand : ICommand
{
    private readonly IOptions<ApiConfig> _apiConfig;
    
    public GetRandomDrinkCommand(IOptions<ApiConfig> apiConfig)
    {
        _apiConfig = apiConfig;
    }
    
    public void Execute()
    {
        throw new NotImplementedException();
    }
}