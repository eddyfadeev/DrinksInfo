using System.ComponentModel.DataAnnotations;

namespace DrinksInfo.Enums;

internal enum FilterMenuEntries
{
    [Display(Name = "Filter by category")]
    CategoryFilters,
    [Display(Name = "Filter by alcoholic")]
    AlcoholicFilters,
    [Display(Name = "Filter by glass type")]
    GlassTypeFilters,
    [Display(Name = "Filter by ingredient")]
    IngredientFilters,
    [Display(Name = "Back")]
    Back
}