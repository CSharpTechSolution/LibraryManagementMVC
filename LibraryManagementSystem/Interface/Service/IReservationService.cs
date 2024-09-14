using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Interface.Service
{
    public interface IReservationService
    {
        Task<BaseResponse<ReservationDto>> GetByDate(DateTime date);
        Task<BaseResponse<ICollection<ReservationDto>>> GetAll();
        Task<BaseResponse<ReservationDto>> Delete(string id);
        Task<BaseResponse<ReservationDto>> AddReservation(CreateReservationRequestModel model);
        Task<BaseResponse<ReservationDto>> Update(string id, UpdateReservationRequestModel model);
    }
}
