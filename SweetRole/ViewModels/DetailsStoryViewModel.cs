using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetRole.Areas.Identity.Data;
using SweetRole.Models;



namespace SweetRole.ViewModels
{
    public class DetailsStoryViewModel
    {

        public List<SelectListItem> Users { get; set; }
        public Story Story { get; set; }
        public DetailsStoryViewModel() { }

        public DetailsStoryViewModel(Story story, IEnumerable<SweetRoleUser> users, string userId)
        {
            Users = new List<SelectListItem>();
            foreach (var user in users)
            {
                // TODO: Get Select List to only display Foreign Usernames
                if (user.UserName == userId)
                {
                    break;
                }
                else
                {
                    Users.Add(new SelectListItem
                    {
                        Value = user.Id.ToString(),
                        Text = user.UserName
                    });
                }

            }
            Story = story;
        }
    }
}
