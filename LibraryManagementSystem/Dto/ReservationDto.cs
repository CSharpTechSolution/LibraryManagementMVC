using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Dto;
public class ReservationDto
{
    public string Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public User? User { get; set; }
    public string BookId { get; set; } = default!;
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}

public class CreateReservationRequestModel
{
    public string UserId { get; set; } = default!;
    public string BookId { get; set; } = default!;
    public DateTime ReservationDate { get; set; }
    public string ReservationStatus { get; set; } = default!;
}

public class UpdateReservationRequestModel
{
    public string UserId { get; set; } = default!;
    public string BookId { get; set; } = default!;
    public DateTime ReservationDate { get; set; }
    public string ReservationStatus { get; set; } = default!;
}
