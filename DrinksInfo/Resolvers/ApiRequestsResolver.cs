using DrinksInfo.Enums;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.Resolvers;
using DrinksInfo.Models;
using Microsoft.Extensions.Options;

namespace DrinksInfo.Resolvers;

internal class ApiRequestsResolver
{
    // private readonly IOptions<ApiConfig> _apiConfig;
    // private readonly IHttpManger _httpManger;
    private readonly IUriResolver _uriResolver;
    
    public ApiRequestsResolver(/*IOptions<ApiConfig> apiConfig, IHttpManger httpManger, */IUriResolver uriResolver)
    {
        //_apiConfig = apiConfig;
        //_httpManger = httpManger;
        _uriResolver = uriResolver;
    }
    
    public void GetRandomDrink()
    {
        var uri = _uriResolver.ResolveUri(ApiEndpoints.Random.RandomCocktail);

        Console.WriteLine(uri.ToString());
    }
}

