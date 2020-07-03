using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialMedia.Core.DTOs
{
    public class PostsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
