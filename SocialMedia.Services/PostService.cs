using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    //CODING HATES ME
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPostsById()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(e => e.AuthorId == _userId).Select(e => new PostListItem { Id = e.Id, Title = e.Title, Text = e.Text });
                return query.ToArray();
            }
        }
        public IEnumerable<PostListItem> GetAllPosts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var posts = ctx.Posts.Select(e => new PostListItem { Id = e.Id, Title = e.Title, Text = e.Text });
                return posts.ToArray();
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.Id == model.Id && e.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Text = model.Text;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.Id == postId && e.AuthorId == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
