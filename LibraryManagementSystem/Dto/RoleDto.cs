namespace LibraryManagementSystem.Dto;

public class RoleDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public IList<UserDto> UserDtos { get; set; } = new List<UserDto>();
}

public class CreateRoleRequestModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}

public class UpdateRoleRequestModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = null!;
}
