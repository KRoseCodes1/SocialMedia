using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        public int PostId { get; set; }

        public string Text { get; set; }

    }
    public class CommentList
    {
        public Guid PostId { get; set; }
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

