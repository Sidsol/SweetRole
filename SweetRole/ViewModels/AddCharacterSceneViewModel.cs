﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SweetRole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.ViewModels
{
    public class AddCharacterSceneViewModel
    {
        [Display(Name = "Character Name")]
        public int CharacterId { get; set; }
        public int SceneId { get; set; }

        public Scene Scene { get; set; }

        public List<SelectListItem> Characters { get; set; }

        public AddCharacterSceneViewModel() { }


        public AddCharacterSceneViewModel(Scene scene, IEnumerable<Character> characters)
        {
            Characters = new List<SelectListItem>();
            foreach (var character in characters)
            {
                Characters.Add(new SelectListItem
                {
                    Value = character.CharacterId.ToString(),
                    Text = character.Name
                });
            }
            Scene = scene;
        }
    }
}
