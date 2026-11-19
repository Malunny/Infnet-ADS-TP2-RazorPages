using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages;

public class CreateMultipleCountries : PageModel
{
    public const int InputsCount = 5;
    [BindProperty] public List<InputModel> Inputs { get; set; } = Enumerable.Range(0, InputsCount).Select(_ => new InputModel()).ToList();
    private readonly CountryService _countryService;
    public CreateMultipleCountries([FromServices] CountryService countryService)
    {
        _countryService = countryService;
    }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        var countries = new List<Country>();
        foreach (var input in Inputs)
        {
            var firstLettersAreTheSame = _countryService.CheckNameAndCodeFirstLettersAreTheSame(input.CountryName,
                input.CountryCode);

            if (!firstLettersAreTheSame)
            {
                ModelState.AddModelError(nameof(input.CountryName), "Country name and code are not the same");
                ModelState.AddModelError(nameof(input.CountryCode), "Country name and code are not the same");
            }
            
            countries.Add(new Country
            {
                CountryName = input.CountryName,
                ContryCode = input.CountryCode
            });
        }
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Some of the inputs were invalid.";
            return Page();
        }
        
        MemoryStorage.Countries.AddRange(countries);

        return RedirectToPage("./CountryListing");
    }

    public class InputModel
    {
        public string CountryName { get; set; }
        [StringLength(2, MinimumLength = 2)] public string CountryCode { get; set; }
    }
}