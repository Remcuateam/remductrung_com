using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Data.Entities;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Services.Systems.Settings;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Services.System.Settings.Dtos;

namespace AspNetMvc.Services.Systems.Settings
{
    public class SystemConfigService : WebServiceBase<Setting, string, SystemConfigViewModel>, ISystemConfigService
    {
        private readonly IRepository<Setting, string> _settingRepository;

        public SystemConfigService(IRepository<Setting, string> settingRepository,
            IUnitOfWork unitOfWork) : base(settingRepository, unitOfWork)
        {
            _settingRepository = settingRepository;
        }

        public override void Add(SystemConfigViewModel systemConfigVm)
        {
            var setting = Mapper.Map<SystemConfigViewModel, Setting>(systemConfigVm);
            _settingRepository.Add(setting);
        }
        public override void Update(SystemConfigViewModel systemConfigVm)
        {
            var setting = Mapper.Map<SystemConfigViewModel, Setting>(systemConfigVm);
            _settingRepository.Update(setting);
        }

        public override void Delete(string id)
        {
            _settingRepository.Remove(id);
        }

        public override SystemConfigViewModel GetById(string id)
        {
            return Mapper.Map<Setting, SystemConfigViewModel>(_settingRepository.GetById(id));
        }

        public override List<SystemConfigViewModel> GetAll()
        {
            return _settingRepository.GetAll().OrderBy(x => x.Id).ProjectTo<SystemConfigViewModel>().ToList();
        }

        public PagedResult<SystemConfigViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _settingRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<SystemConfigViewModel>()
            {
                Results = data.ProjectTo<SystemConfigViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

    }
}