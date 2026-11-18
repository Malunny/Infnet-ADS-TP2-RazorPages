using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CityListing : PageModel
{
    public List<string> Cities { get; set; } = ["Rio", "São Paulo", "Brasília"];
    public void OnGet()
    {
        
    }
}