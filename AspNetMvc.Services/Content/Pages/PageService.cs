using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.Content.Pages;
using AspNetMvc.Services.Content.Pages.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Utilities.Helpers;

namespace AspNetMvc.Services.Content.Pages
{
    public class PageService : WebServiceBase<Page, int, PageViewModel>, IPageService
    {
        private readonly IRepository<Page, int> _pageRepository;       

        public PageService(IRepository<Page, int> pageRepository,
            IUnitOfWork unitOfWork) : base(pageRepository, unitOfWork)
        {
            _pageRepository = pageRepository;           
        }

        public override void Add(PageViewModel pageVm)
        {
            if (!string.IsNullOrEmpty(pageVm.PageAlias))
            {
                pageVm.PageAlias = TextHelper.ToUnsignString(pageVm.Name);
            }
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Add(page);
        }

        public override void Update(PageViewModel pageVm)
        {
            if(!string.IsNullOrEmpty(pageVm.PageAlias))
            {
                pageVm.PageAlias = TextHelper.ToUnsignString(pageVm.Name);
            }
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Update(page);
        }

        public override void Delete(int id)
        {
            _pageRepository.Remove(id);
        }

        public override PageViewModel GetById(int id)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.GetById(id));
        }
     
        public override List<PageViewModel> GetAll()
        {
            return _pageRepository.GetAll().OrderBy(x=>x.CreatedDate).ProjectTo<PageViewModel>().ToList();
        }

        public PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize=1)
        {
            var query = _pageRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<PageViewModel>()
            {
                Results = data.ProjectTo<PageViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public PageViewModel GetByAlias(string alias)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.Single(x => x.PageAlias == alias));
        }
    }
}