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
        private CommentService CreateComment()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateComment();
            var comments = commentService.GetCommentbyPostId();
            return Ok(comments);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateComment();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int AuthorId)
        {
            CommentService commentService = CreateComment();
            var comment = commentService.GetAuthorCommentsbyId();
            return Ok(comment);

        }
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateComment();
            if (!service.UpdateComment(comment))
                return InternalServerError();
            return Ok();

        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateComment();
            if (!service.DeleteComment(id))
                return InternalServerError();
            return Ok();
        }

    }
}
