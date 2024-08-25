using System.Net.Http.Headers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.Resolvers;

namespace DrinksInfo.HttpManager;

internal class HttpManager : IHttpManger
{
    private readonly IUriResolver _uriResolver;
    
    public HttpManager(IUriResolver uriResolver)
    {
        _uriResolver = uriResolver;
    }

    public string GetResponse<TApi>(TApi request, string? parameters = null) 
        where TApi : Enum
    {
        var uri = _uriResolver.ResolveUri(request, parameters);
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(SetAcceptHeader());

        var response = client.GetAsync(uri).Result;
        
        return response.IsSuccessStatusCode ? 
            response.Content.ReadAsStringAsync().Result : 
            "[red]Problem processing request![/]";
    }
    
    private static MediaTypeWithQualityHeaderValue SetAcceptHeader() => 
        new("application/json");
}