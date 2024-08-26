using DrinksInfo.Models;

namespace DrinksInfo.Interfaces.HttpManager;

internal interface IHttpManger
{
    public Drinks GetResponse<TApi>(TApi request, string? parameters = null)
        where TApi : Enum;
}