using SweetRole.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.Models
{
    public class Character
    {

        public int CharacterId { get; set; }

        [Required]
        public string Name { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime DateOfBirth { get; set; }

        [Required]
        public string SweetRoleUserId { get; set; }
        public virtual SweetRoleUser SweetRoleUser { get; set; }

    }
}
