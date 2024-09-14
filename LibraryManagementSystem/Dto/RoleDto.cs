using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Dto
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserDto> UserDtos { get; set; } = new List<UserDto>();
    }

    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateRoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
