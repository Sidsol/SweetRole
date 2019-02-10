using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.ViewModels
{
    public class EditCharacterViewModel
    {
        [Required(ErrorMessage = "Characters must have a name")]
        [Display(Name = "Characters Name")]
        public string Name { get; set; }
    }
}
