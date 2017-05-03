using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VideoGameLogger.Models;

namespace VideoGameLogger.Controllers
{
    public class VideoGamesApiController : ApiController
    {
        private VideoGameLoggerContext db = new VideoGameLoggerContext();

        // GET: api/VideoGamesApi
        public IQueryable<VideoGame> GetVideoGames()
        {
            return db.VideoGames;
        }

        // GET: api/VideoGamesApi/5
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult GetVideoGame(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return Ok(videoGame);
        }

        // PUT: api/VideoGamesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideoGame(int id, VideoGame videoGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoGame.VideoGameID)
            {
                return BadRequest();
            }

            db.Entry(videoGame).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VideoGamesApi
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult PostVideoGame(VideoGame videoGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideoGames.Add(videoGame);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = videoGame.VideoGameID }, videoGame);
        }

        // DELETE: api/VideoGamesApi/5
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult DeleteVideoGame(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            db.VideoGames.Remove(videoGame);
            db.SaveChanges();

            return Ok(videoGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoGameExists(int id)
        {
            return db.VideoGames.Count(e => e.VideoGameID == id) > 0;
        }
    }
}