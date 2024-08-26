using DrinksInfo.Enums;
using DrinksInfo.Handlers;
using DrinksInfo.HttpManager;
using DrinksInfo.Interfaces.Handlers;
using DrinksInfo.Interfaces.HttpManager;
using DrinksInfo.Interfaces.Mappers;
using DrinksInfo.Interfaces.Resolvers;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.Mappers;
using DrinksInfo.Models;
using DrinksInfo.View;
using DrinksInfo.View.Factory;
using DrinksInfo.View.Factory.Initializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrinksInfo.Services;

internal static class ServicesConfigurator
{
    public static ServiceCollection ServiceCollection { get; } = new();
    public static IConfiguration Configuration { get; }
    
    static ServicesConfigurator()
    {
        Configuration = GetConfiguration().Build();
        ConfigureServices(ServiceCollection);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ApiConfig>(Configuration.GetSection("ApiConfig"));
        
        services.AddTransient<IMenuCommandFactory<MainMenuEntries>, MenuCommandFactory<MainMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<FilterMenuEntries>, MenuCommandFactory<FilterMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<SearchMenuEntries>, MenuCommandFactory<SearchMenuEntries>>();

        services.AddTransient<IMenuEntriesInitializer<MainMenuEntries>, MainMenuEntriesInitializer>();
        services.AddTransient<IMenuEntriesInitializer<FilterMenuEntries>, FilterMenuEntriesInitializer>();
        services.AddTransient<IMenuEntriesInitializer<SearchMenuEntries>, SearchMenuEntriesInitializer>();

        services.AddTransient<IMenuEntries<MainMenuEntries>, MenuEntries<MainMenuEntries>>();
        services.AddTransient<IMenuEntries<FilterMenuEntries>, MenuEntries<FilterMenuEntries>>();
        services.AddTransient<IMenuEntries<SearchMenuEntries>, MenuEntries<SearchMenuEntries>>();

        services.AddSingleton<IMenuEntriesHandler<MainMenuEntries>, MenuEntriesHandler<MainMenuEntries>>();
        services.AddSingleton<IMenuEntriesHandler<FilterMenuEntries>, MenuEntriesHandler<FilterMenuEntries>>();
        services.AddSingleton<IMenuEntriesHandler<SearchMenuEntries>, MenuEntriesHandler<SearchMenuEntries>>();
        
        services.AddTransient<IUriResolver, UriResolver>();
        services.AddTransient<IApiEndpointMapper, ApiEndpointMapper>();
        services.AddTransient<IHttpManger, HttpManager.HttpManager>();
        services.AddTransient<ITableConstructor, TableConstructor>();
    }

    private static IConfigurationBuilder GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder;
    }
}