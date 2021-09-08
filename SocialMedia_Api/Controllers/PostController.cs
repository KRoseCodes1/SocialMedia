using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia_Api.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetAllPosts();
            return Ok(posts);
        }
        [HttpGet]
        [Route("[action]")]
        public IHttpActionResult GetAllByAuthor()
        {
                PostService postService = CreatePostService();
                var posts = postService.GetPostsById();
                return Ok(posts);
        }
        [HttpPost]
        public IHttpActionResult CreateNewPost(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.CreatePost(post))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult UpdateCurrentPost(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.UpdatePost(post))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(id))
                return InternalServerError();
            return Ok();
        }
    }
}
