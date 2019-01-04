using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services
{
    public interface IWebServiceBase<TEntity,TPrimaryKey,ViewModel> where ViewModel : class
        where TEntity : DomainEntity<TPrimaryKey>
    {
        void Add(ViewModel viewModel);
        void Update(ViewModel viewModel);
        void Delete(TPrimaryKey id);
        ViewModel GetById(TPrimaryKey id);
        List<ViewModel> GetAll();
        PagedResult<ViewModel> GetAllPaging(Expression<Func<TEntity, bool>> predicate, Func<TEntity, bool> orderBy, SortDirection sortDirection, int page, int pageSize);
        void Save();
    }
}
