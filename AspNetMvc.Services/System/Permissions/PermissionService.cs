using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc.Services.System.Permissions.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Infrastructure.Interfaces;
using System;

namespace AspNetMvc.Services.System.Permissions
{
    public class PermissionService : WebServiceBase<Permission, int, PermissionViewModel>,IPermissionService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IRepository<Function, string> _functionRepository;       
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        //private IUnitOfWork _unitOfWork;

        public PermissionService(IRepository<Permission, int> permissionRepository,
              IRepository<Function, string> functionRepository,
              RoleManager<AppRole> roleManager,
              UserManager<AppUser> userManager,
            IUnitOfWork unitOfWork) : base(permissionRepository, unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _functionRepository = functionRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override void Add(PermissionViewModel permissionVm)
        {
            var permission = Mapper.Map<PermissionViewModel, Permission>(permissionVm);
            _permissionRepository.Add(permission);
        }

        // public override void Update(PermissionViewModel permissionVm);

        // public override void Delete(Guid id);
       
        public void DeleteAll(string functionId)
        {
            _permissionRepository.Remove(x => x.FunctionId == functionId);
            //var permissions = _permissionRepository.FindAll(x => x.FunctionId == functionId).ToList();
            //_permissionRepository.Delete(permissions);
        }

        public ICollection<PermissionViewModel> GetByFunctionId(string functionId)
        {
            return _permissionRepository.GetAll().Where(x => x.FunctionId == functionId).ProjectTo<PermissionViewModel>().ToList();
            //return _permissionRepository
            //    .FindAll(x => x.FunctionId == functionId, x => x.AppRole)
            //    .ProjectTo<PermissionViewModel>().ToList();
        }

        public async Task<List<PermissionViewModel>> GetByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            var query = (from f in _functionRepository.GetAll()
                         join p in _permissionRepository.GetAll() on f.Id equals p.FunctionId
                         join r in _roleManager.Roles on p.RoleId equals r.Id
                         where roles.Contains(r.Name)
                         select p);

            //var query = (from f in _functionRepository.FindAll()
            //             join p in _permissionRepository.FindAll() on f.Id equals p.FunctionId
            //             join r in _roleManager.Roles on p.RoleId equals r.Id
            //             where roles.Contains(r.Name)
            //             select p);

            return query.ProjectTo<PermissionViewModel>().ToList();
        }


    }
}