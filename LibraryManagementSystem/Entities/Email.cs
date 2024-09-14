using LibraryManagementSystem.Contract;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Entities
{
    public class Email : AuditableEntity
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public EmailType EmailType { get; set; }
    }
}
