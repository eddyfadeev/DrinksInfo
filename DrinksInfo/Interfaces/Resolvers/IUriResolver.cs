namespace DrinksInfo.Interfaces.Resolvers;

internal interface IUriResolver
{
    public Uri ResolveUri<TApi>(TApi endpoint, string? parameter = null) 
        where TApi : Enum;
}