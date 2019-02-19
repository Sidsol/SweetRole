using Microsoft.AspNetCore.Mvc.Rendering;
using SweetRole.Areas.Identity.Data;
using SweetRole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SweetRole.ViewModels
{
    public class DetailsStoryViewModel
    {
        public List<SelectListItem> Users { get; set; }
        public Story Story { get; set; }
        public DetailsStoryViewModel() { }

        public DetailsStoryViewModel(Story story, IEnumerable<SweetRoleUser> users)
        {
            Users = new List<SelectListItem>();
            foreach (var user in users)
            {
                Users.Add(new SelectListItem
                {
                    Value = user.Id.ToString(),
                    Text = user.UserName
                });
            }
            Story = story;
        }
    }
}
