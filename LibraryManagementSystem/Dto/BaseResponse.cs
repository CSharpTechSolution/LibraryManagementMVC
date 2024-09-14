namespace LibraryManagementSystem.Dto
{
    public class BaseResponse<T>
    {
        public string Mesage {  get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
