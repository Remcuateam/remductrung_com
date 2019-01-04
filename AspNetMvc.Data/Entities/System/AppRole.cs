using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AspNetMvc.Data.Entities.System
{       
    [Table("AppRoles")]

    /// AppRole inherit from IdentityRole:
    /// using Microsoft.AspNetCore.Identity;   
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {

        }
        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        [StringLength(255)]
        public string Description { get; set; }
        
    }
}