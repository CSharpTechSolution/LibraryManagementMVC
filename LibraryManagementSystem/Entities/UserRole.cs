using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities
{
    public class UserRole : AuditableEntity
    {
        public string? RoleId { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
