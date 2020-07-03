using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.DTOs
{
    public class ComentsDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
