using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;

namespace DrinksInfo.View.Commands.SearchMenuCommands;

internal class SearchByIngredientCommand : BaseSearchCommand<string>
{
    public SearchByIngredientCommand(IHttpManger httpManager, ITableConstructor tableConstructor) : base(httpManager, tableConstructor)
    {
    }

    public override void Execute()
    {
        
    }

    private protected override Drinks FetchQuery(string input)
    {
        throw new NotImplementedException();
    }

    private protected override string[] FetchPropertyArray(Drinks drinks)
    {
        throw new NotImplementedException();
    }
}