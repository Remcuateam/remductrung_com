using System;
using System.Collections.Generic;
using AspNetMvc.Services.Content.Slides.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Enums;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Slides
{
    public interface ISlideService : IWebServiceBase<Slide, int, SlideViewModel>
    {      
        //void Add(SlideViewModel slideVm);
        //void Update(SlideViewModel slideVm);    
        //void Delete(int id);
        //SlideViewModel GetById(int id);
        //List<SlideViewModel> GetAll();  
        PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize);
        List<SlideViewModel> GetSlides(SlideGroup groupAlias);

    }
}