namespace LibraryManagementSystem.Dto;
public class BaseResponse<T>
{
    public string? Message { get; set; }
    public string? Status { get; set; }
    public T? Data { get; set; }
}
