using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages;

public class CreateCountry : PageModel
{
    [BindProperty] public InputModel Input { get; set; }
    private readonly CountryService _countryService;
    public CreateCountry([FromServices] CountryService countryService)
    {
        _countryService = countryService;
    }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost(InputModel input)
    {
        var firstLettersAreTheSame = _countryService.CheckNameAndCodeFirstLettersAreTheSame(input.CountryName,
            input.CountryCode);

        if (!firstLettersAreTheSame)
        {
            ModelState.AddModelError(nameof(input.CountryName), "Country name and code are not the same");
            ModelState.AddModelError(nameof(input.CountryCode), "Country name and code are not the same");
        }

        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Some of the inputs were invalid.";
            return Page();
        }

        var country = new Country
        {
            CountryName = input.CountryName,
            ContryCode =  input.CountryCode
        };
        
        return Page();
    }

    public class InputModel
    {
        public string CountryName { get; set; }
        [StringLength(2, MinimumLength = 2)] public string CountryCode { get; set; }
    }
}