using System;
using AspNetMvc.Services.System.Users.Dtos;

namespace AspNetMvc.Services.System.Announcements.Dtos
{
    public class AnnouncementUserViewModel
    {
        public Guid AnnouncementId { get; set; }
        public Guid UserId { get; set; }
        public bool? HasRead { get; set; }

        public virtual AppUserViewModel AppUser { get; set; }

        public virtual AnnouncementViewModel Announcement { get; set; }
    }
}