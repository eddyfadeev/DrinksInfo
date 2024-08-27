# Architecture Overview of the DrinksInfo Application

## Introduction

The DrinksInfo application is designed to provide users with detailed information about various drinks, allowing them to search, filter, and explore drinks based on various criteria such as name, category, ingredients, and glass type. The application leverages a RESTful API to fetch drinks data and presents it to the user in an interactive command-line interface (CLI).

## High-Level Architecture

The application is structured into several main components:

1. **Models**: Defines the data structures used throughout the application.
2. **View**: Manages user interaction and display formatting.
3. **Commands**: Contains the logic for handling user commands and interactions.
4. **HttpManager**: Responsible for making HTTP requests and processing responses.
5. **Services**: Provides additional utilities like configuration and user input handling.
6. **Mappers**: Handles mapping of API endpoints and JSON data transformation.
7. **Handlers**: Manages dynamic menu entries and command execution based on user input.
8. **Resolvers**: Responsible for constructing URIs for API requests.
9. **Exceptions**: Defines custom exceptions for handling specific error scenarios.
10. **Program**: The entry point of the application, orchestrating the flow based on user interactions.

## Diagram
![alt text](https://github.com/eddyfadeev/DrinksInfo/blob/master/Drinks_Info_diagram.png?raw=true)

## Detailed Component Breakdown

### Models
- **Drink** (`Drink.cs`): Represents a single drink entity.
- **Drinks** (`Drinks.cs`): A collection of `Drink` objects, supporting indexed access.
- **ApiConfig** (`ApiConfig.cs`): Configuration model for API endpoints.

### View
- **TableConstructor** (`TableConstructor.cs`): Constructs tables for displaying drink information.
- **MenuEntries** (`MenuEntries.cs`): Retrieves menu entries for different menu types.
- **Messages** (`Messages.cs`): Contains static message strings used across the application.

### Commands
- Commands are divided into categories based on their purpose:
  - **SearchMenuCommands**: Commands related to searching drinks (`SearchByNameCommand.cs`, `SearchByIngredientCommand.cs`).
  - **FilterMenuCommands**: Commands for filtering drinks (`FilterByCategoryCommand.cs`, `FilterByGlassCommand.cs`, etc.).
  - **MainMenuCommands**: Commands that are executed from the main menu (`GetRandomDrinkCommand.cs`, `OpenSearchCommand.cs`, `OpenFilterByCommand.cs`).

### HttpManager
- **HttpManager** (`HttpManager.cs`): Implements the `IHttpManger` interface to handle HTTP requests and responses.

### Services
- **ServicesConfigurator** (`ServicesConfigurator.cs`): Sets up dependency injection and service configuration.
- **UserChoiceService** (`UserChoiceService.cs`): Utility for capturing user input.
- **HelpService** (`HelpService.cs`): Utility for common helper methods like waiting for user input.

### Mappers
- **ApiEndpointMapper** (`ApiEndpointMapper.cs`): Maps API endpoints to their corresponding relative paths.
- **DrinkMapper** (`DrinkMapper.cs`): Custom JSON converter for the `Drink` model.

### Handlers
- **MenuEntriesHandler** (`MenuEntriesHandler.cs`): Handles the display and selection of menu entries.
- **DynamicEntriesHandler** (`DynamicEntriesHandler.cs`): Manages dynamic entries for user selection.

### Resolvers
- **UriResolver** (`UriResolver.cs`): Constructs complete URIs for API requests based on configuration and endpoint mapping.

### Exceptions
- **ExitApplicationException** and **ReturnToPreviousMenuException** handle specific flow control scenarios within the application.

### Entry Point
- **Program** (`Program.cs`): Initializes services and starts the main application loop.

## Architectural Invariants

- **Separation of Concerns**: Each component in the system has a well-defined responsibility, ensuring that the application remains modular and maintainable.
- **No Cyclic Dependencies**: The components are structured to prevent cyclic dependencies, ensuring a unidirectional flow of data and control.
- **Configuration-Driven**: API endpoints and other configurations are loaded from `appsettings.json`, making the system flexible and adaptable to changes without requiring code modifications.

## Conclusion

The architecture of the DrinksInfo application is designed to be modular, maintainable, and scalable. By separating concerns into well-defined components and leveraging dependency injection, the application ensures that enhancements and modifications can be made with minimal impact on existing functionality.
