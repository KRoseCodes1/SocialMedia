using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
    public class CommentList
    {
        public int PostId { get; set; }
    }
    public class AuthorComment
    {
        public Guid AuthorId { get; set; }
    }
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
    }



}

