using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    //NO
    public class PostCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        public string Text { get; set; }

    }
}
