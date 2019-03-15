using SweetRole.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.ViewModels
{
    public class AddCharacterViewModel
    {
        [Required(ErrorMessage ="Characters must have a name")]
        [Display(Name = "Characters Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Sexual Orientation")]
        public string SexualOrientation { get; set; }

        [Display(Name = "Height")]
        public double Height { get; set; }

        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Display(Name = "Eye Color")]
        public string EyeColor { get; set; }

        [Display(Name = "Hair Color")]
        public string HairColor { get; set; }

        [Display(Name = "Race")]
        public string Race { get; set; }

        [Display(Name = "Species")]
        public string Species { get; set; }

        [Display(Name = "Background")]
        public string BackStory { get; set; }

        [Display(Name = "Miscellaneous")]
        public string Miscellaneous { get; set; }
    }
}
