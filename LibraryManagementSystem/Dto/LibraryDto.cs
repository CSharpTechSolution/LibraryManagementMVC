namespace LibraryManagementSystem.Dto;
public class LibraryDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
}

public class CreateLibraryRequestModel
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ContactNumber { get; set; } = null!;
}

public class UpdateLibraryRequestModel
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
}
