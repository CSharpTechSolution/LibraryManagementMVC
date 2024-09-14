namespace LibraryManagementSystem.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<RoleDto> RoleDtos { get; set; } = new List<RoleDto>();
    }

    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
