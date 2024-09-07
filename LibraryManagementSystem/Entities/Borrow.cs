using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities;
public class Borrow : AuditableEntity
{
    public string UserId { get; set; } = default!;
    public User? User { get; set; }
    public string BookId { get; set; } = default!;
    public Book? Book { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime BorrowDate { get; set; }

}