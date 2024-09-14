namespace LibraryManagementSystem.Dto
{
    public class BookDto
    { 
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public string LibraryId { get; set; }
       
    }

    public class CreateBookRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
        public string LibraryId { get; set; }

    }

    public class UpdateBookRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
    }
}
