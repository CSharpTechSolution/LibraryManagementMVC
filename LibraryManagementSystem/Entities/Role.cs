using LibraryManagementSystem.Contract;
using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Entities
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserRole> UserRoles { get; set; }
    }

    
}
