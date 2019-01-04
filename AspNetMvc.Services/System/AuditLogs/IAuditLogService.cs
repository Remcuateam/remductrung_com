using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Data.Entities;

namespace AspNetMvc.Services.Systems.AuditLogs
{
    public interface IAuditLogService : IWebServiceBase<Error, string, ErrorViewModel>
    {
        void Create(Error error);

        void Save();
    }
}
