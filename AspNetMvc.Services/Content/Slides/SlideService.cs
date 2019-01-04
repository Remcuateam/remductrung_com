using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.Content.Slides.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Slides
{
    public class SlideService : WebServiceBase<Slide, int, SlideViewModel>, ISlideService
    {
        private readonly IRepository<Slide, int> _slideRepository;

        public SlideService(IRepository<Slide, int> slideRepository,
            IUnitOfWork unitOfWork) : base(slideRepository, unitOfWork)
        {
            _slideRepository = slideRepository;
        }

        public override void Add(SlideViewModel slideVm)
        {
            var slide = Mapper.Map<SlideViewModel, Slide>(slideVm);
            _slideRepository.Add(slide);
        }
        public override void Update(SlideViewModel slideVm)
        {
            var slide = Mapper.Map<SlideViewModel, Slide>(slideVm);
            _slideRepository.Update(slide);
        }

        public override void Delete(int id)
        {
            _slideRepository.Remove(id);
        }

        public override SlideViewModel GetById(int id)
        {
            return Mapper.Map<Slide, SlideViewModel>(_slideRepository.GetById(id));
        }

        public override List<SlideViewModel> GetAll()
        {
            return _slideRepository.GetAll().OrderBy(x => x.SortOrder).ProjectTo<SlideViewModel>().ToList();
        }       

        public PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _slideRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.SortOrder)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<SlideViewModel>()
            {
                Results = data.ProjectTo<SlideViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<SlideViewModel> GetSlides(SlideGroup groupAlias)
        {
            return _slideRepository.GetAll().Where(x => x.Status == Status.Actived && x.GroupAlias == groupAlias).OrderBy(x => x.SortOrder)
                .ProjectTo<SlideViewModel>().ToList();
        }

    }
}