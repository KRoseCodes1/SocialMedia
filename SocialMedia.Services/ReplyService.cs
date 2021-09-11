using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Data;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                AuthorId = _userId,
                Text = model.Text,
                CommentId = model.CommentId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SingleReply> GetReplies()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Replies
                    .Where(e => e.AuthorId == _userId)
                    .Select(e =>
                        new SingleReply
                        {
                            Id = e.Id,
                            Text = e.Text,
                            CommentId = e.CommentId
                        }
                    );
                return query.ToArray();
            }
        }
    }
}
