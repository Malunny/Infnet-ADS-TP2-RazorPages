using WebApp.Models;

namespace WebApp;

public static class MemoryStorage
{
    public static List<Country> Countries { get; set; } = new();
}