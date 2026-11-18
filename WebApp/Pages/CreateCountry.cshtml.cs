using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages;

public class CreateCountry : PageModel
{
    [BindProperty] public InputModel Input { get; set; }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost(InputModel input)
    {
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