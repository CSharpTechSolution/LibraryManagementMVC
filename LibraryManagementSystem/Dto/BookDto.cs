namespace LibraryManagementSystem.Dto;
public class BookDto
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Author { get; set; } = null!;
    public string ISBN { get; set; } = default!;
    public int PublishedYear { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool IsAvailable { get; set; } 
    public string LibraryId { get; set; } = default!;

}

public class CreateBookRequestModel
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public int PublishedYear { get; set; } = default!;
    public string Category { get; set; } = default!;
}

public class UpdateBookRequestModel
{
    public string? Title { get; set; } 
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public int PublishedYear { get; set; }
}

