using DrinksInfo.Interfaces.Mappers;
using DrinksInfo.Interfaces.Resolvers;
using DrinksInfo.Models;
using Microsoft.Extensions.Options;

namespace DrinksInfo.HttpManager;

internal class UriResolver : IUriResolver
{
    private readonly IApiEndpointMapper _apiEndpointMapper;
    private readonly string _baseUrl;
    
    public UriResolver(IApiEndpointMapper apiEndpointMapper, IOptions<ApiConfig> apiConfig)
    {
        _apiEndpointMapper = apiEndpointMapper ?? throw new ArgumentNullException(nameof(apiEndpointMapper));
        _baseUrl = apiConfig.Value.BaseUrl ?? throw new ArgumentException("[red]API configuration is missing![/]");
    }

    public Uri ResolveUri<TApi>(TApi endpoint, string? parameter = null) 
        where TApi : Enum
    {
        string relativePath = _apiEndpointMapper.GetRelativePath(endpoint);
        
        if (!string.IsNullOrEmpty(parameter))
        {
            relativePath = string.Format(relativePath, parameter);
        }

        return new Uri($"{_baseUrl}{relativePath}");
    }
}