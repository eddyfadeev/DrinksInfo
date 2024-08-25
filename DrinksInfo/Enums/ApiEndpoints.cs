namespace DrinksInfo.Enums;

internal static class ApiEndpoints
{
    public enum Lists
    {
        Categories = 1,
        Ingredients,
        Glasses,
        AlcoholicOptions
    }

    public enum Search
    {
        CocktailByName,
        IngredientByName,
        CocktailByFirstLetter
    }

    public enum Lookup
    {
        CocktailById,
        IngredientById
    }

    public enum Filter
    {
        ByIngredient,
        ByAlcoholic,
        ByCategory,
        ByGlass
    }
    
    public enum Random
    {
        RandomCocktail
    }
}