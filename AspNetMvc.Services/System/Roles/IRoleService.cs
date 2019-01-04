using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetMvc.Services.System.Permissions.Dtos;
using AspNetMvc.Services.System.Roles.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.System.Roles
{
    public interface IRoleService 
    {
        Task<bool> AddAsync(AppRoleViewModel userVm);        

        Task UpdateAsync(AppRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        //void DeleteAll();

        Task<AppRoleViewModel> GetById(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
     
        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(string functionCode, string action, string[] roles);
    }
}
