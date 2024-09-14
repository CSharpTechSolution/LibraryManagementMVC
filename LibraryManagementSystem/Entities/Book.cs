using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities
{
    public class Book : AuditableEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public string LibraryId { get; set; }
        public Library Library { get; set; }

    }
}
