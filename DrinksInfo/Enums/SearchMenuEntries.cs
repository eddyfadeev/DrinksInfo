using System.ComponentModel.DataAnnotations;

namespace DrinksInfo.Enums;

internal enum SearchMenuEntries
{
    [Display(Name = "Search by name")]
    Name,
    [Display(Name = "Search by ingredient")]
    Ingredient,
    [Display(Name = "Search by category")]
    Category,
    [Display(Name = "Search by glass type")]
    GlassType,
    [Display(Name = "Back")]
    Back
}