using SweetRole.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.Models
{
    public class Story
    {
        public int StoryId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string Genre { get; set; }

        [Required]
        public string SweetRoleUserId { get; set; }
        public virtual SweetRoleUser SweetRoleUser { get; set; }
    }
}
