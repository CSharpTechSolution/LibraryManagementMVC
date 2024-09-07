namespace LibraryManagementSystem.Dto;
public class BorrowDto
{
    public string Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string BookId { get; set; } = default!;
    public DateTime ReturnDate { get; set; }
    public DateTime BorrowDate { get; set; }
}

public class CreateBorrowRequestModel
{
    public string UserId { get; set; } = default!;
    public string BookId { get; set; } = default!;
    public DateTime ReturnDate { get; set; }
    public DateTime BorrowDate { get; set; }
}

public class UpdateBorrowRequestModel
{
    public string UserId { get; set; } = default!;
    public string BookId { get; set; } = null!;
    public DateTime ReturnDate { get; set; }
    public DateTime BorrowDate { get; set; }
}

