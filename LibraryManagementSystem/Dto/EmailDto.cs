﻿using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Dto
{
    public class EmailDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string EmailType { get; set; }
    }

    public class CreateEmailRequestModel
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public string EmailType { get; set; }
    }

    public class UpdateEmailRequestModel
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public EmailType EmailType { get; set; }
    }


}
