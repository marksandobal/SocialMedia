using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Data
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
