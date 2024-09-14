using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Interface.Service
{
    public interface ILibraryService
    {
        Task<BaseResponse<LibraryDto>> Register(CreateLibraryRequestModel model);
    }
}
