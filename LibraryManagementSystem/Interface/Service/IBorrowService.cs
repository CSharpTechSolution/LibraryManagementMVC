using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Interface.Service
{
    public interface IBorrowService
    {
        
        Task<BaseResponse<ICollection<BorrowDto>>> GetAllBorrowedBook();
        Task<BaseResponse<BorrowDto>> DeleteBorrowedBook(string BorrowedBookId);
        Task<BaseResponse<BorrowDto>> UpdateAllBorrowed(string id, UpdateBorrowRequestModel model);
        Task<BaseResponse<BorrowDto>> GetBorrowedBook(string id);
        Task<BaseResponse<BorrowDto>> Register(CreateBorrowRequestModel model);
    }
}
