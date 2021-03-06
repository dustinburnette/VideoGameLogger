﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameLogger.Models;

namespace VideoGameLogger.Controllers
{
    [Authorize]
    public class VideoGamesController : Controller
    {
        private VideoGameLoggerContext db = new VideoGameLoggerContext();

        // GET: VideoGames
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var videoGames = db.VideoGames.Where(videoGame => videoGame.CreatedBy == userId).Include(v => v.NameOfCharacter);
            return View(videoGames.ToList());
        }

        // GET: VideoGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null || videoGame.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
           
            return View(videoGame);
        }

        // GET: VideoGames/Create
        public ActionResult Create()
        {
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName");
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameID,NameOfFightingGame,WinOrLose,NumberOfRounds,CharacterID,HowLongMinutes,RecordTimeMinutes")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                videoGame.CreatedBy = User.Identity.GetUserId();
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", videoGame.CharacterID);
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null || videoGame.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", videoGame.CharacterID);
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameID,NameOfFightingGame,WinOrLose,NumberOfRounds,CharacterID,HowLongMinutes,RecordTimeMinutes")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", videoGame.CharacterID);
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null || videoGame.CreatedBy != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
