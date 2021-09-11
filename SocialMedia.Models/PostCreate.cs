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
        [Required]
        public Guid AuthorId { get; set; }
        public virtual List<Reply> Replies { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post post { get; set; }

    }
}
