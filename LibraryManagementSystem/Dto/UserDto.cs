namespace LibraryManagementSystem.Dto;
public class UserDto
{
    public string Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public IList<RoleDto> RoleDtos { get; set; } = new List<RoleDto>();
}

public class LoginRequestModel
{
    public string Email { get; set; } = default!;
    public string PassWord { get; set; } = default!;
}
