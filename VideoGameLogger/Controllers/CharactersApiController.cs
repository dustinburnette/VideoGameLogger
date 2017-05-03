﻿using System;
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
    public class CharactersApiController : ApiController
    {
        private VideoGameLoggerContext db = new VideoGameLoggerContext();

        // GET: api/CharactersApi
        public IQueryable<Character> GetCharacters()
        {
            return db.Characters;
        }

        // GET: api/CharactersApi/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult GetCharacter(int id)
        {
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/CharactersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.CharacterID)
            {
                return BadRequest();
            }

            db.Entry(character).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/CharactersApi
        [ResponseType(typeof(Character))]
        public IHttpActionResult PostCharacter(Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Characters.Add(character);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = character.CharacterID }, character);
        }

        // DELETE: api/CharactersApi/5
        [ResponseType(typeof(Character))]
        public IHttpActionResult DeleteCharacter(int id)
        {
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }

            db.Characters.Remove(character);
            db.SaveChanges();

            return Ok(character);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterExists(int id)
        {
            return db.Characters.Count(e => e.CharacterID == id) > 0;
        }
    }
}