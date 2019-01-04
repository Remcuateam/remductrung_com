using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Services.System.Users.Dtos;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.System.Announcements.Dtos
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
            AnnouncementUsers = new List<AnnouncementUserViewModel>();
        }

        public Guid UserId { set; get; }

        [StringLength(255)]
        [Required]
        public string Title { set; get; }
        public string Content { set; get; }
        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }

        public AppUserViewModel AppUser { get; set; }

        public virtual ICollection<AnnouncementUserViewModel> AnnouncementUsers { get; set; }
    }
}