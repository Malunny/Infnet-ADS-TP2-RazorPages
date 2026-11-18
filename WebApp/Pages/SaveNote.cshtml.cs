using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class SaveNote : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public void OnGet()
    {
        
    }

    public IActionResult OnPost(InputModel input)
    {
        var timestamp = DateTime.Now;
        System.IO.File.WriteAllText($"./wwwroot/note-{timestamp.ToLongTimeString()}.txt", Input.Content);

        return Page();
    }

    public class InputModel
    {
        [Required] public string Content { get; set; }
    }
}