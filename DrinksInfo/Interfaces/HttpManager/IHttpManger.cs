namespace DrinksInfo.Interfaces.HttpManager;

internal interface IHttpManger
{
    public string GetResponse<TApi>(TApi request, string? parameters = null)
        where TApi : Enum;
}