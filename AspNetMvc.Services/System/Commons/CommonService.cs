using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.Content.Slides.Dtos;
using AspNetMvc.Services.System.Settings.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Constants;
using System;
using AspNetMvc.Services.Content.Footers.Dtos;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Entities.System;

namespace AspNetMvc.Services.System.Commons
{
    public class CommonService : ICommonService
    {
        private readonly IRepository<Footer, string> _footerRepository;
        private readonly IRepository<Setting, string> _systemConfigRepository;       
        private readonly IRepository<Slide, int> _slideRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<Setting, string> systemConfigRepository,          
            IRepository<Slide, int> slideRepository,
             IUnitOfWork unitOfWork) 
        {
            _footerRepository = footerRepository;         
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.Single(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        //public List<SlideViewModel> GetSlides(SlideGroup groupAlias)
        //{
        //    return _slideRepository.GetAll().Where(x => x.Status == Status.Actived && x.GroupAlias == groupAlias).OrderBy(x => x.SortOrder)
        //        .ProjectTo<SlideViewModel>().ToList();
        //}

        //public SystemConfigViewModel GetSystemConfig(string code)
        //{
        //    return Mapper.Map<Setting, SystemConfigViewModel>(_systemConfigRepository.Single(x => x.UniqueCode == code));
        //}
    }
}