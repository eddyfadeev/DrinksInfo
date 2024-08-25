using DrinksInfo.Enums;
using DrinksInfo.Interfaces.Mappers;
using DrinksInfo.Models;
using Microsoft.Extensions.Options;

namespace DrinksInfo.Mappers;

internal class ApiEndpointMapper : IApiEndpointMapper
{
    private readonly ApiConfig _apiConfig;
    private readonly Dictionary<Type, Dictionary<string, string>> _endpoints;
    
    public ApiEndpointMapper(IOptions<ApiConfig> apiConfig)
    {
        _apiConfig = apiConfig.Value ?? 
                     throw new ArgumentNullException(nameof(apiConfig), "[red]API configuration is missing![/]");
        _endpoints = InitializeEndpoints();
    }
    
    public string GetRelativePath<TApi>(TApi endpoint) where TApi : Enum
    {
        if (!_endpoints.TryGetValue(endpoint.GetType(), out var resultEndpoint))
        {
            throw new ArgumentOutOfRangeException(
                nameof(endpoint), 
                $"[red]No endpoints found for type '{endpoint.GetType().Name}'[/]"
            );
        }

        return GetEndpointPath(resultEndpoint, endpoint.ToString()!);
    }

    private Dictionary<Type, Dictionary<string, string>> InitializeEndpoints() =>
        new()
        {
            { typeof(ApiEndpoints.Lists), _apiConfig.Lists },
            { typeof(ApiEndpoints.Search), _apiConfig.Search },
            { typeof(ApiEndpoints.Lookup), _apiConfig.Lookup },
            { typeof(ApiEndpoints.Filter), _apiConfig.Filter },
            { 
                typeof(ApiEndpoints.Random), 
                new Dictionary<string, string> {
                    {
                        "RandomCocktail", _apiConfig.RandomCocktail! 
                    } 
                } 
            }
        };
    
    private static string GetEndpointPath(Dictionary<string, string> endpoints, string key)
    {
        if (endpoints.TryGetValue(key, out string path))
        {
            return path;
        }
        throw new ArgumentException($"[red]Endpoint path for '{key}' not found in the configuration![/]");
    }
}