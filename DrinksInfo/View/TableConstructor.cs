using DrinksInfo.Interfaces.View;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.View;

internal sealed class TableConstructor : ITableConstructor
{
    public Table CreateDrinkTable(Drink drink)
    {
        var table = new Table();
        table.AddColumn("");
        ConfigureMainTable(table);
        AddMainTableTitle(table, drink);
        AddSupportInfo(table, drink);
        AddIngredientsAndMeasures(table, drink);
        AddInstructions(table, drink);

        return table;
    }

    private static void ConfigureMainTable(Table table)
    {
        table.Border = TableBorder.Rounded;
        table.HideHeaders();
        table.HideFooters();
        table.Width(60);
    }

    private static void AddMainTableTitle(Table table, Drink drink) => 
        table.Title(drink.DrinkName);

    private static void InitializeSubTable(Table subTable, string title, int columns)
    {
        subTable.Title(title);
        subTable.HideHeaders();
        subTable.Border(TableBorder.None);
        subTable.Centered();
        subTable.HideFooters();
        
        for (var i = 0; i < columns; i++)
        {
            subTable.AddColumn(new TableColumn(""));
        }
    }
    
    private static void AddSupportInfo(Table table, Drink drink)
    {
        const int supportInfoColumnsNum = 2;
        var supportInfoTable = new Table();
        InitializeSubTable(supportInfoTable, "Drink Information", supportInfoColumnsNum);
        
        supportInfoTable.AddEmptyRow();
        supportInfoTable.AddRow("Category:", drink.DrinkCategory);
        supportInfoTable.AddRow("Alcoholic:", drink.IsAlcoholic);
        supportInfoTable.AddRow("Glass Type:", drink.DrinkGlassType);

        table.AddRow(supportInfoTable);
    }
    
    private static void AddIngredients(Table ingredientsTable, Drink drink)
    {
        const int measuresColumnsNum = 1;
        InitializeSubTable(ingredientsTable, "", measuresColumnsNum);
        foreach (var ingredient in drink.Ingredients)
        {
            ingredientsTable.AddRow(ingredient);
        }
    }
    
    private static void AddMeasures(Table measuresTable, Drink drink)
    {
        const int measuresColumnsNum = 1;
        InitializeSubTable(measuresTable, "", measuresColumnsNum);
        foreach (var measure in drink.Measures)
        {
            measuresTable.AddRow(measure);
        }
    }

    private static void AddIngredientsAndMeasures(Table table, Drink drink)
    {
        const int ingredientsColumnsNum = 2;
        var ingredientsAndMeasuresTable = new Table();
        InitializeSubTable(ingredientsAndMeasuresTable, "Ingredients", ingredientsColumnsNum);

        var ingredientsTable = new Table();
        InitializeSubTable(ingredientsTable, "Ingredients", 1);
        AddIngredients(ingredientsTable, drink);

        var measuresTable = new Table();
        AddMeasures(measuresTable, drink);

        ingredientsAndMeasuresTable.AddRow(ingredientsTable, measuresTable);

        table.AddRow(ingredientsAndMeasuresTable);
    }
    
    private static void AddInstructions(Table table, Drink drink)
    {
        const int instructionsColumnsNum = 1;
        var instructionsTable = new Table();
        InitializeSubTable(instructionsTable, "Instructions", instructionsColumnsNum);
        
        instructionsTable.AddRow(drink.DrinkInstructions);
        
        table.AddRow(instructionsTable);
    }
}