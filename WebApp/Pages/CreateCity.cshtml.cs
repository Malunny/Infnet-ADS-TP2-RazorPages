using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CreateCity : PageModel
{
    public void OnGet()
    {
        
    }

    public void OnPost(InputModel input)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid input";
            return;
        }

        TempData["CityName"] = input.CityName;
    }

    public class InputModel
    {
        [MinLength(3)] [Required] public string CityName { get; set; }
    }
}