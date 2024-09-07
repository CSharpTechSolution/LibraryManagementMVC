using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Implementation;
public class Email
{
    public string Content { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public EmailType EmailType { get; set; }
}
