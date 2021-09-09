using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SocialMedia.Data
{
    public class Post
    {
        [ForeignKey(nameof(Posts))]
        public int PostId { get; set; }
        public virtual Post Posts { get; set; }
        public string Title { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Guid AuthorId { get; set; }
    }
}
