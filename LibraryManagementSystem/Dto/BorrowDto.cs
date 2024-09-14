using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Dto
{
    public class BorrowDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }
        public BookDto Book { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
    }

    public class CreateBorrowRequestModel
    {
        public string UserId { get; set; }
        public User user { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
    }

    public class UpdateBorrowRequestModel
    {
        public string UserId { get; set; }
        public User user { get; set; }
        public string BookId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set;}
    }
}
