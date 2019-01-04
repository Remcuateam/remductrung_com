using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc.Services.System.Functions.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Constants;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Utilities.Helpers;

namespace AspNetMvc.Services.System.Functions
{
    public class FunctionService : WebServiceBase<Function, string, FunctionViewModel>, IFunctionService
    {
        private readonly IRepository<Function, string> _functionRepository;
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        

        public FunctionService(
             IRepository<Function, string> functionRepository,
             IRepository<Permission, int> permissionRepository,
             RoleManager<AppRole> roleManager,
             UserManager<AppUser> userManager,
             //IMapper mapper,
            IUnitOfWork unitOfWork) : base(functionRepository, unitOfWork)
        {
            _functionRepository = functionRepository;
            _permissionRepository = permissionRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
        }
        
        public override void Add(FunctionViewModel functionVm)
        {
            var function = Mapper.Map<FunctionViewModel,Function>(functionVm);
            _functionRepository.Add(function);
        }

        public override void Update(FunctionViewModel functionVm)
        {
            var functionDb = _functionRepository.GetById(functionVm.Id);
            var function = Mapper.Map<FunctionViewModel,Function>(functionVm);
            _functionRepository.Update(function);
        }            
        
        public override void Delete(string id)
        {
            _functionRepository.Remove(id);
        }

        public override FunctionViewModel GetById(string id)
        {
            //var function = _functionRepository.FindSingle(x => x.Id == id);
            var function = _functionRepository.Single(x => x.Id == id);
            return Mapper.Map<Function, FunctionViewModel>(function);
        }

        //public override List<FunctionViewModel> GetAll()
        //{
        //    return _functionRepository.GetAll().OrderBy(x => x.ParentId)
        //        .ProjectTo<FunctionViewModel>()
        //        .ToList();
        //}

        //public PagedResult<FunctionViewModel> GetAllPaging(string keyword, int page, int pageSize)
        //{
        //    var query = _functionRepository.GetAll();
        //    if (!string.IsNullOrEmpty(keyword))
        //        query = query.Where(x => x.Name.Contains(keyword));

        //    int totalRow = query.Count();
        //    var data = query.OrderByDescending(x => x.CreatedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize);
        //    var paginationSet = new PagedResult<FunctionViewModel>()
        //    {
        //        Results = data.ProjectTo<FunctionViewModel>().ToList(),
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize,
        //    };
        //    return paginationSet;
        //}

        public Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var query = _functionRepository.GetAll().Where(x => x.Status == Status.Actived);
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));
            return query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }

        //public Task<List<FunctionViewModel>> GetAllList()
        //{
        //    var query = _functionRepository.GetAll().Where(x => x.Status == Status.Actived);
            
        //    return query.OrderBy(x => x.SortOrder).ProjectTo<FunctionViewModel>().ToListAsync();
        //}

        public async Task<List<FunctionViewModel>> GetAllWithPermission(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            var query = (from f in _functionRepository.GetAll()
                         join p in _permissionRepository.GetAll() on f.Id equals p.FunctionId
                         join r in _roleManager.Roles on p.RoleId equals r.Id
                         where roles.Contains(r.Name)
                         select f);

            var parentIds = query.Select(x => x.ParentId).Distinct();

            query = query.Union(_functionRepository.GetAll().Where(f => parentIds.Contains(f.Id)));

            return await query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId)
        {
            return _functionRepository.GetAll().Where(x => x.ParentId == parentId).ProjectTo<FunctionViewModel>();
        }

        public bool CheckExistedId(string id)
        {
            return _functionRepository.GetById(id) != null;
        }

        public void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            //Update parent id for source
            var category = _functionRepository.GetById(sourceId);
            category.ParentId = targetId;
            _functionRepository.Update(category);

            //Get all sibling
            var sibling = _functionRepository.GetAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _functionRepository.Update(child);
            }
        }

        public void ReOrder(string sourceId, string targetId)
        {
            var source = _functionRepository.GetById(sourceId);
            var target = _functionRepository.GetById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;
            _functionRepository.Update(source);
            _functionRepository.Update(target);
        }
    }
}