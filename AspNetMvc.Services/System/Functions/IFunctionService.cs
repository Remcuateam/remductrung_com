using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetMvc.Services.System.Functions.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;

namespace AspNetMvc.Services.System.Functions
{
    public interface IFunctionService : IWebServiceBase<Function, string, FunctionViewModel>
    {    //void Add(FunctionViewModel functionVm);
        //void Update(FunctionViewModel functionVm);
        //void Delete(string id);
        //FunctionViewModel GetById(string id);
        //List<FunctionViewModel> GetAll();   
        //PagedResult<FunctionViewModel> GetAllPaging(string keyword, int page, int pageSize);
        Task<List<FunctionViewModel>> GetAll(string filter);
        //Task<List<FunctionViewModel>> GetAllList();
        Task<List<FunctionViewModel>> GetAllWithPermission(string userName);
        IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId);        
        bool CheckExistedId(string id);
        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);
        void ReOrder(string sourceId, string targetId); 
    }
}