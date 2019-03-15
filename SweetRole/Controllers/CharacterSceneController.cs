using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetRole.Models;
using SweetRole.ViewModels;

namespace SweetRole.Controllers
{
    public class CharacterSceneController : Controller
    {
        private readonly SweetRoleContext _context;

        public CharacterSceneController(SweetRoleContext context)
        {
            _context = context;
        }
        // GET: CharacterScene
        public ActionResult Index()
        {
            return View();
        }

        // GET: CharacterScene/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharacterScene/Create
        public ActionResult AddCharacter(int id)
        {
            Scene scene = _context.Scenes.Single(m => m.SceneID == id);
            List<Character> characters = _context.Characters.ToList();
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
                return RedirectToAction(nameof(Index));
            }
            return View(addCharacterSceneViewModel);

        }

        // GET: CharacterScene/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CharacterScene/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterScene/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharacterScene/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}