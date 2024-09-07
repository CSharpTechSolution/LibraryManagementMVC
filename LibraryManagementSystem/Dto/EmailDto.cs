using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Dto;

public class EmailDto
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string EmailType { get; set; } = default!;    
}

public class CreateEmailRequestModel
{
    public string Content { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string EmailType { get; set; } = default!;
}

public class UpdateEmailRequestModel
{
    // why Updating Email
    public string Content { get; set; }
    public string Subject { get; set; }
    public EmailType EmailType { get; set; }
}

