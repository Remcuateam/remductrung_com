using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AspNetMvc.Data.Entities.System
{  
    [Table("AppUsers")]

    /// AppUser inherit from IdentityUser:
    /// using Microsoft.AspNetCore.Identity;   
    public class AppUser : IdentityUser, ISwitchable, IDateTracking
    {
        public AppUser()
        {
        }

        public AppUser(string fullName, string userName,
            string email, string phoneNumber, string address, string gender, string avatar, Status status)
        {
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Avatar = avatar;
            Status = status;
        }

        public AppUser(string id, string fullName, string userName,
            string email, string phoneNumber, string address, string gender, string avatar, Status status)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Avatar = avatar;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { set; get; }
    }
}