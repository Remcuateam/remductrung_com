using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetMvc.Services.System.Functions.Dtos;
using AspNetMvc.Services.System.Roles.Dtos;

namespace AspNetMvc.Services.System.Permissions.Dtos
{
    public class PermissionViewModel
    {

        public int Id { get; set; }


        public Guid RoleId { get; set; }

        public string FunctionId { get; set; }

        public bool CanCreate { set; get; }

        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public AppRoleViewModel AppRole { get; set; }

        public FunctionViewModel Function { get; set; }
    }
}