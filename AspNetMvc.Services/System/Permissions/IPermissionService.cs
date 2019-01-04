using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetMvc.Services.System.Permissions.Dtos;

namespace AspNetMvc.Services.System.Permissions
{
    public interface IPermissionService
    {
        void Add(PermissionViewModel permission);
        //void Update(PermissionViewModel permission);
        //void Delete(Guid id);
        void DeleteAll(string functionId);
        ICollection<PermissionViewModel> GetByFunctionId(string functionId);
        //List<FunctionViewModel> GetAll();   
        //PagedResult<FunctionViewModel> GetAllPaging(string keyword, int page, int pageSize);
        Task<List<PermissionViewModel>> GetByUserId(Guid userId);         
    }
}