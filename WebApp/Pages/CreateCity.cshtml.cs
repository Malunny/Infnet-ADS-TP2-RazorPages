using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CreateCity : PageModel
{
    public void OnGet()
    {
        
    }

    public void OnPost(string cityName)
    {
        Console.WriteLine(cityName);
        TempData["CityName"] = cityName;
    }
}