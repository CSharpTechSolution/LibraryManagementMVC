using LibraryManagementSystem.Contract;
namespace LibraryManagementSystem.Entities;

public class Role : AuditableEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<UserRole>? UserRoles { get; set; }
}


