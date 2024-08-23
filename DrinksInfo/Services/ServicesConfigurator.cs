using DrinksInfo.Enums;
using DrinksInfo.Interfaces.View;
using DrinksInfo.Interfaces.View.Factory;
using DrinksInfo.View;
using DrinksInfo.View.Factory;
using DrinksInfo.View.Factory.Initializers;
using Microsoft.Extensions.DependencyInjection;

namespace DrinksInfo.Services;

public static class ServicesConfigurator
{
    internal static ServiceCollection ServiceCollection { get; } = new();
    
    static ServicesConfigurator()
    {
        ConfigureServices(ServiceCollection);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IMenuCommandFactory<MainMenuEntries>, MenuCommandFactory<MainMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<FilterMenuEntries>, MenuCommandFactory<FilterMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<SearchMenuEntries>, MenuCommandFactory<SearchMenuEntries>>();

        services.AddTransient<IMenuEntriesInitializer<MainMenuEntries>, MainMenuEntriesInitializer>();

        services.AddTransient<IMenuEntries<MainMenuEntries>, MenuEntries<MainMenuEntries>>();

        services.AddSingleton<IMenuEntriesHandler<MainMenuEntries>, MenuEntriesHandler<MainMenuEntries>>();
    }
}