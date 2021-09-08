using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public virtual List<Comment> Comments {
            get {
                return _comments;
            }
            set {
                using (var ctx = new ApplicationDbContext())
                {
                    var _comments = ctx.Comments.Where(e => e.PostId == Id).Select(e => new CommentListItem { Id = e.Id, Text = e.Text, AuthorId = e.AuthorId });
                }
            }
        }
        public virtual List<Like> Likes {
            get
            {
                return _likes;
            }
            set
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var _comments = ctx.Comments.Where(e => e.PostId == Id).Select(e => new LikeListItem { Id = e.Id, OwnerId = e.OwnerId});
                }
            }
        }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
