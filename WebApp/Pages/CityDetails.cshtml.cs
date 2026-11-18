using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class CityDetails : PageModel
{
    public string CityName { get; set; }
    public void OnGet(string cityName)
    {
        CityName = cityName;
    }
}