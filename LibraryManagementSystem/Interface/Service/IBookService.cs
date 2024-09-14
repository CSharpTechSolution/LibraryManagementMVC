using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Interface.Service
{
    public interface IBookService
    {
        Task<BaseResponse<BookDto>> Register(CreateBookRequestModel model);
        Task<BaseResponse<ICollection<BookDto>>> GetAll();
        Task<BaseResponse<BookDto>> Delete(string BookId);
        Task<BaseResponse<BookDto>> Update(string id, UpdateBookRequestModel model);
        Task<BaseResponse<BookDto>> Get(string id);
        Task<BaseResponse<BookDto>> GetByName(string name);
    }
}
