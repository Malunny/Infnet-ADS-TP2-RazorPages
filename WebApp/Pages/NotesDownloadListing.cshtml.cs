using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class NotesDownloadListing : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public List<Note> Notes { get; set; } = new();

    public NotesDownloadListing(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        FeedNotes();
    }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnGetDownloadNote(string fileName)
    {
        var note = Notes.FirstOrDefault(n => n.Name == fileName);

        if (note == null)
            return NotFound();
        
        return PhysicalFile(note.Href, "plain/text", fileDownloadName: note.Name); 
    }

    private void FeedNotes()
    {
        var notesFiles = Directory.EnumerateFiles(_webHostEnvironment.WebRootPath, "*.txt");
        Notes.AddRange(notesFiles.Select(f => new Note { Href = f, Name = Path.GetFileName(f) }));
    }

    public class Note
    {
        public string Href { get; set; }
        public string Name { get; set; }
    }
}