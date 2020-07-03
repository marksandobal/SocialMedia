using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.DTOs
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
