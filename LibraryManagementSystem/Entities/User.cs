using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities;
public class User : AuditableEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
