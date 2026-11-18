using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CreateCity : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        Console.WriteLine(ModelState.IsValid);
        Console.WriteLine(Input.CityName);
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid input";
            return Page();
        }

        TempData["CityName"] = Input.CityName;
        return Page();
    }

    public class InputModel
    {
        [MinLength(3)] [Required] public string CityName { get; set; }
    }
}