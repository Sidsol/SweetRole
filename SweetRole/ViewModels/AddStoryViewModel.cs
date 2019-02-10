using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.ViewModels
{
    public class AddStoryViewModel
    {
        [Required]
        [Display(Name = "Title of Story")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Genre of the Story")]
        public string Genre { get; set; }
    }
}
