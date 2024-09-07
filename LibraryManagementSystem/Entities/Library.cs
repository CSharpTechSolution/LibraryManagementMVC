using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities;
public class Library : AuditableEntity
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
}
