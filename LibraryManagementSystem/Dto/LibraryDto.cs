namespace LibraryManagementSystem.Dto
{
    public class LibraryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
    }

    public class CreateLibraryRequestModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
    }

    public class UpdateLibraryRequestModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }
    }
}
