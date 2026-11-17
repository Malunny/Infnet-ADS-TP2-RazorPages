using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CreateCity : PageModel
{
    [BindProperty] public string CityName { get; set; } 
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        TempData["CityName"] = CityName;
    }
}