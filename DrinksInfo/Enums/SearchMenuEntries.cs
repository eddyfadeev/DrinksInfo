using System.ComponentModel.DataAnnotations;

namespace DrinksInfo.Enums;

internal enum SearchMenuEntries
{
    [Display(Name = "Search by first letter")]
    SearchByFirstLetter,
    [Display(Name = "Search by name")]
    SearchByName,
    [Display(Name = "Search by ingredient")]
    SearchByIngredient,
    [Display(Name = "Back")]
    Back
}