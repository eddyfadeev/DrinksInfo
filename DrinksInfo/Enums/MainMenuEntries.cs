using System.ComponentModel.DataAnnotations;

namespace DrinksInfo.Enums;

internal enum MainMenuEntries
{
    [Display(Name = "Get a random drink")]
    GetRandom,
    [Display(Name = "Search for a drink")]
    SearchMenu,
    [Display(Name = "Filter drinks")]
    FiltersMenu,
    [Display(Name = "Exit")]
    Exit
}