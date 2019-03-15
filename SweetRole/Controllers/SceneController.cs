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

            Scene scene = await _context.Scenes
                .Include(s => s.CharacterScenes)
                .FirstOrDefaultAsync(m => m.SceneID == id);

            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }
        // GET: Scene/Create
        public async Task<ActionResult> Create(int? id)
        {
            Story story = await _context.Stories
                .FirstOrDefaultAsync(s => s.StoryID == id);

            return View(new AddSceneViewModel(story));
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
                    StoryID = addSceneViewModel.StoryID
                };

                _context.Add(newScene);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = newScene.SceneID });
            }
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
            if (id != scene.SceneID)
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

                    if (!StoryExists(scene.SceneID))
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
                .FirstOrDefaultAsync(m => m.SceneID == id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }

        // POST: Scene/Delete/5
        [HttpPost, ActionName("Delete")]
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
            return _context.Scenes.Any(e => e.SceneID == id);
        }
        // GET: CharacterScene/Create
        public async Task<ActionResult> AddCharacter(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Scene scene = _context.Scenes.Single(m => m.SceneID == id);
            List<Character> characters = await _context.Characters.Where(c => c.SweetRoleUserId == userId).ToListAsync();

            return View(new AddCharacterSceneViewModel(scene, characters));
        }

        // POST: CharacterScene/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCharacter(AddCharacterSceneViewModel addCharacterSceneViewModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var characterId = addCharacterSceneViewModel.CharacterID;
                var sceneId = addCharacterSceneViewModel.SceneID;

                ICollection<CharacterScene> existingItems = _context.CharacterScenes
                    .Where(cs => cs.CharacterID == characterId)
                    .Where(cs => cs.SceneID == sceneId).ToList();
                if (existingItems.Count == 0)
                {
                    CharacterScene addCharacter = new CharacterScene
                    {

                        Character = _context.Characters.Single(c => c.CharacterID == characterId),
                        Scene = _context.Scenes.Single(s => s.SceneID == sceneId)
                    };

                    _context.Add(addCharacter);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Details", new { id = sceneId });
            }
            return View(addCharacterSceneViewModel);

        }
    }
}