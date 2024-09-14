using LibraryManagementSystem.Contract;

namespace LibraryManagementSystem.Entities
{
    public class Library : AuditableEntity
    {
        public string Name {  get; set; } 
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
    }
}
