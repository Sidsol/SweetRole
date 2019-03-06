﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetRole.Areas.Identity.Data;
using SweetRole.Models;
using SweetRole.ViewModels;

namespace SweetRole.Controllers
{
    public class StoryController : Controller
    {
        private readonly SweetRoleContext _context;

        public StoryController(SweetRoleContext context)
        {
            _context = context;
        }



        // GET: Story
        public async Task<ActionResult> Index()
        {
            var userId = "";
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return View(await _context.Stories.Where(x => x.SweetRoleUserId == userId).ToListAsync());
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

        }

        // GET: Story/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<SweetRoleUser> users = await _context.Users.ToListAsync();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Story story = await _context.Stories
                .Include(s => s.Scenes)
                .FirstOrDefaultAsync(s => s.StoryID == id);
            if (story == null)
            {
                return NotFound();
            }
            //return View(story);
            return View(new DetailsStoryViewModel(story, users, userId));
        }

        // POST: Share Story with User
        //public async Task<AcceptedResult> Details()
        //{
        //    return View();
        //}

        

        // GET: Story/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddStoryViewModel addStoryViewModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {

                // Add the new Character to my existing Characters
                Story newStory = new Story
                {
                    Title = addStoryViewModel.Title,
                    DateCreated = DateTime.Now,
                    Genre = addStoryViewModel.Genre,
                    SweetRoleUserId = userId
                };

                _context.Add(newStory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = newStory.StoryID });
            }
            return View(addStoryViewModel);

        }


        // GET: Story/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Story/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("StoryID, Title, DateCreated, Genre, SweetRoleUserId")] Story story)
        {
            if (id != story.StoryID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!StoryExists(story.StoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET: Story/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Stories
                .FirstOrDefaultAsync(m => m.StoryID == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var story = await _context.Stories.FindAsync(id);
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.StoryID == id);
        }
    }
}