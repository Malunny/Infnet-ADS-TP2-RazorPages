using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages;

public class CreateMultipleCountries : PageModel
{
    public const int InputsCount = 5;
    [BindProperty] public List<InputModel> Inputs { get; set; } = Enumerable.Range(0, InputsCount).Select(_ => new InputModel()).ToList();
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Some of the inputs were invalid.";
            return Page();
        }

        MemoryStorage.Countries.Clear();
        
        foreach (var input in Inputs)
            MemoryStorage.Countries.Add(new Country
            {
                CountryName = input.CountryName,
                ContryCode = input.CountryCode
            });
        
        return RedirectToPage("./CountryListing");
    }

    public class InputModel
    {
        public string CountryName { get; set; }
        [StringLength(2, MinimumLength = 2)] public string CountryCode { get; set; }
    }
}