using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(3000, ErrorMessage = "Post is too large.")]
        public string Text { get; set; }
    }
}
