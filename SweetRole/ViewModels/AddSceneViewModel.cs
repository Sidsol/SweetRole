using SweetRole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.ViewModels
{
    public class AddSceneViewModel
    {
        [Required]
        [Display(Name = "Scene Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Scene Setting")]
        public string Setting { get; set; }

        [Required]
        public int StoryId { get; set; }

        public Story Story { get; set; }
        public AddSceneViewModel() { }


        public AddSceneViewModel(Story story)
        {
            Story = story;
        }
    }
}
