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
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentbyPostId();
            return Ok(comments);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int AuthorId)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetAuthorCommentsbyId();
            return Ok(comment);

        }
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.UpdateComment(comment))
                return InternalServerError();
            return Ok();

        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(id))
                return InternalServerError();
            return Ok();
        }

    }
}
