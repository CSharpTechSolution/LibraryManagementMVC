using LibraryManagementSystem.Contract;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Entities
{
    public class Reservation : AuditableEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}
