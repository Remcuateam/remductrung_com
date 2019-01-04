using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services
{
    /// <summary>
    /// Base webserice for all services
    /// Creator: Toanbn
    /// Created Date: May 10, 2018
    /// </summary>
    /// <typeparam name="TEntity">Main entity for WS</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type for main entity</typeparam>
    /// <typeparam name="ViewModel">View Model class</typeparam>
    public abstract class WebServiceBase<TEntity, TPrimaryKey, ViewModel> : IWebServiceBase<TEntity, TPrimaryKey, ViewModel>
        where ViewModel : class
        where TEntity : DomainEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected WebServiceBase(IRepository<TEntity, TPrimaryKey> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public virtual void Add(ViewModel viewModel)
        {
            var model = Mapper.Map<ViewModel, TEntity>(viewModel);
            _repository.Add(model);
            //_repository.Insert(model);
        }

        public virtual void Update(ViewModel viewModel)
        {
            var model = Mapper.Map<ViewModel, TEntity>(viewModel);
            _repository.Update(model);
        }

        public virtual void Delete(TPrimaryKey id)
        {
            _repository.Remove(id);
        }

        public virtual ViewModel GetById(TPrimaryKey id)
        {
            return Mapper.Map<TEntity, ViewModel>(_repository.GetById(id));
        }

        public virtual List<ViewModel> GetAll()
        {
            return _repository.GetAll().ProjectTo<ViewModel>().ToList();
        }

        public virtual PagedResult<ViewModel> GetAllPaging(Expression<Func<TEntity, bool>> predicate, Func<TEntity, bool> orderBy, SortDirection sortDirection, int page, int pageSize)
        {
            var query = _repository.GetAll().Where(predicate);
            int totalRow = query.Count();
            if(sortDirection==SortDirection.Ascending)
            {
                query  = query.OrderBy(orderBy).Skip((page-1)*pageSize).Take(pageSize).AsQueryable();
            }
            else
            {
                query = query.OrderByDescending(orderBy).Skip((page - 1) * pageSize).Take(pageSize).AsQueryable();
            }
            var data = query.ProjectTo<ViewModel>().ToList();
            var paginationSet = new PagedResult<ViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;        
        }       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        //public override List<ProductViewModel> GetAll()
        //{
        //    var query = (from pc in _productCategoryRepository.GetAll()
        //                 join p in _productRepository.GetAll()
        //                     on pc.Id equals p.CategoryId
        //                 select new { p, pc });

        //    var model = query.OrderByDescending(x => x.p.DateCreated)
        //        .Select(x => new ProductViewModel()
        //        {
        //            Name = x.p.Name,
        //            Id = x.p.Id,
        //            CategoryId = x.p.CategoryId,
        //            CategoryName = x.pc.Name,
        //            Price = x.p.Price,
        //            ThumbnailImage = x.p.ThumbnailImage,
        //            DateCreated = x.p.DateCreated,
        //            Status = x.p.Status
        //        }).ToList();

        //    return model;
        //}

    }
}
