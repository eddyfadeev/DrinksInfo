using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Services;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal abstract class BaseSearchCommand : BaseCommand<string>
{
    private protected abstract string UserPrompt { get; }
    
    protected BaseSearchCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }
    
    public override void Execute()
    {
        while (true)
        {
            var userInput = GetUserInput();
            var drinks = FetchQuery(userInput);
            
            var userChoice = GetUserDrinkChoice(drinks);
            if (userChoice == null)
            {
                continue;
            }
            
            var drink = FetchDrink(userChoice);

            DisplayDrinkDetail(drink);
            break;
        }
    }
    
    private string GetUserInput() => 
        UserChoiceService.GetUserInput<string>(UserPrompt);
}