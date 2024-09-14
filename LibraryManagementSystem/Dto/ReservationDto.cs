using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Dto
{
    public class ReservationDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BookId { get; set; }
        public BookDto Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }

    public class CreateReservationRequestModel
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationStatus { get; set; }
    }

    public class UpdateReservationRequestModel
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationStatus { get; set; }
    }
}
