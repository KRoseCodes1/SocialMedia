using SocialMedia_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SocialMedia;
using SocialMedia.Data;

namespace SocialMedia_Api.Controllers
{
    public class LikeController : ApiController
    {
        
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        //POST
        //api/SocialMedia
        [HttpPost]
        public async Task<IHttpActionResult>Like([FromBody]Like model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            // If the model is valid 
            if (ModelState.IsValid)
            {
                // Store the model in the database
                _context.Likes.Add(model);
                await _context.SaveChangesAsync();

                return Ok("Your social media was created");
            }

            // The model is not valid, go ahead and reject it
            return BadRequest(ModelState);
        }

        //Get All
        //api restraunts 
        [HttpGet]
        public async Task<IHttpActionResult> GetLikesbyPostID()
        {
            List<Like> likes = await _context.Likes.ToListAsync();
            return Ok(likes);
        }

        //Get by ID
        // api/Like/(id)
        [HttpGet]
        public async Task<IHttpActionResult> GetLikesbyOwnerID([FromUri] int id)
        {
            Like like = await _context.Likes.FindAsync(id);

            if(like != null)
            {
                return Ok(like);
            }

            return NotFound();
        }

        // PUT (Update)
        //api/Like/(id)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateLike([FromUri] int id, [FromBody] Like updateLike)
        {
            // Check the ids if they match
            if(id != updateLike?.Id)
            {
                return BadRequest("Ids do not match.");
            }

            // Check the ModelState
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Find the Like in the database
            Like like = await _context.Likes.FindAsync(id);

            // If the Like does not exist then do something
            if (like is null)
                return NotFound();

            //Update the properties
            like.Id = updateLike.Id;
            like.OwnerID = updateLike.OwnerID;
            

            // Save the changes
            await _context.SaveChangesAsync();

            return Ok("The Likes was updated");
        }

        // DELETE
        // api/Like/(id)
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteALike([FromUri]int id)
        {
            Like like = await _context.Likes.FindAsync(id);

            

            if (like is null)
                return NotFound();

            _context.Likes.Remove(like);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The Like was deleted.");
            }

            return InternalServerError();

        }



    }
}
