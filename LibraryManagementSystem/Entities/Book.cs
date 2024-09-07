using LibraryManagementSystem.Contract;
namespace LibraryManagementSystem.Entities;
public class Book : AuditableEntity
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public int PublishedYear { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool IsAvailable { get; set; }
    public string LibraryId { get; set; } = default!;
    public Library Library { get; set; } = default!;

}
