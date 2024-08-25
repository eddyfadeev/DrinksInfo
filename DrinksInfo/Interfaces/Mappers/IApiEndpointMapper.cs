namespace DrinksInfo.Interfaces.Mappers;

internal interface IApiEndpointMapper
{
    string GetRelativePath<TApi>(TApi endpoint) where TApi : Enum;
}