using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
namespace SocialMedia.Core.Data
{
    public partial class Posts : BaseEntity
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
