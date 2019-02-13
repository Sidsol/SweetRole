using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetRole.Models;
using SweetRole.ViewModels;

namespace SweetRole.Controllers
{
    public class SceneController : Controller
    {
        private readonly SweetRoleContext _context;

        public SceneController(SweetRoleContext context)
        {
            _context = context;
        }
        // GET: Scene
        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(await _context.Scenes.Where(x => x.Story.SweetRoleUserId == userId).ToListAsync());
        }

        // GET: Scene/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes
                .FirstOrDefaultAsync(m => m.SceneId == id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }
        // GET: Scene/Create
        public ActionResult Create()
        {

            ViewData["StoryID"] = _context.Stories;
            return View();
        }

        // POST: Scene/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddSceneViewModel addSceneViewModel)
        {
            
            if (ModelState.IsValid)
            {

                // Add the new Character to my existing Characters
                Scene newScene = new Scene
                {
                    Name = addSceneViewModel.Name,
                    Setting = addSceneViewModel.Setting,
                    StoryID = addSceneViewModel.StoryId
                };

                _context.Add(newScene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoryID"] = _context.Stories;
            return View(addSceneViewModel);

        }

        // GET: Scene/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes.FindAsync(id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }

        // POST: Scene/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Title")] Scene scene)
        {
            if (id != scene.SceneId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scene);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!StoryExists(scene.SceneId))
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
            return View(scene);
        }

        // GET: Scene/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes
                .FirstOrDefaultAsync(m => m.SceneId == id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }

        // POST: Scene/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var scene = await _context.Scenes.FindAsync(id);
            _context.Scenes.Remove(scene);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool StoryExists(int id)
        {
            return _context.Scenes.Any(e => e.SceneId == id);
        }
    }
}