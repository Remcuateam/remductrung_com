using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Infrastructure.Interfaces;

namespace AspNetMvc.Services.System.AuditLogs
{
    public class AuditLogService : WebServiceBase<Error, string, ErrorViewModel>, IAuditLogService 
    {
        private IRepository<Error, string> _errorRepository;
        private IUnitOfWork _unitOfWork;

        public AuditLogService(IRepository<Error, int> errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}