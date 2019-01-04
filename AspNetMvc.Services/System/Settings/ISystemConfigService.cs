using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Services.System.Settings.Dtos;
using AspNetMvc.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Services.Systems.Settings
{
    public interface ISystemConfigService : IWebServiceBase<Setting, string, SystemConfigViewModel>
    {
        PagedResult<SystemConfigViewModel> GetAllPaging(string keyword, int page, int pageSize);
        //
        //void Add(SystemConfigViewModel systemConfigVm);
        //void Update(SystemConfigViewModel systemConfigVm);
        //void Delete(Guid id);
        //SystemConfigViewModel GetById(Guid id);
        //List<SystemConfigViewModel> GetAll();
    }
}
