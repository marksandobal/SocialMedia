using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Data
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
