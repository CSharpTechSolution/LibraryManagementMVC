using LibraryManagementSystem.Contract;
using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }


}
