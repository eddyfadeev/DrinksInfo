using System.Net.Http.Headers;
using DrinksInfo.Extensions;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.Resolvers;
using DrinksInfo.Models;

namespace DrinksInfo.HttpManager;

internal class HttpManager : IHttpManger
{
    private readonly IUriResolver _uriResolver;
    
    public HttpManager(IUriResolver uriResolver)
    {
        _uriResolver = uriResolver;
    }

    public Drinks GetResponse<TApi>(TApi request, string? parameters = null) 
        where TApi : Enum
    {
        var uri = _uriResolver.ResolveUri(request, parameters);
        using var client = CreateHttpClient();

        var response = client.GetAsync(uri).Result;
        EnsureSuccessStatusCode(response);
        
        var content = response.Content.ReadAsStringAsync().Result;
        return ProcessResponseContent(content);
    }

    private static HttpClient CreateHttpClient()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(SetAcceptHeader());
        return client;
    }
    
    private static MediaTypeWithQualityHeaderValue SetAcceptHeader() => 
        new("application/json");
    
    private static void EnsureSuccessStatusCode(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
    }
    
    private static Drinks ProcessResponseContent(string content)
    {
        return content.ConvertToDrinksList();
    }
}