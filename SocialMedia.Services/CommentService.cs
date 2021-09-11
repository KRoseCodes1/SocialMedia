using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = _userId,
                Text = model.Text,
                PostId = model.PostId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReturnComment> GetCommentbyPostId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select(e => new ReturnComment
                    {
                        Id = e.CommentId,
                        Text = e.Text,
                        PostId = e.PostId          
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<AuthorComment> GetAuthorCommentsbyId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments
                                .Where(e => e.AuthorId == _userId)
                                .Select(e => new AuthorComment
                                {
                                    AuthorId = e.AuthorId
                                });
                return query.ToArray();
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =ctx
                    .Comments
                    .Single(e => e.PostId == model.CommentId && e.Text == model.Text);
                
                entity.Text = model.Text;
                entity.CommentId = model.CommentId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Comments
                       .Single(e => e.CommentId == commentId && e.AuthorId == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }

}