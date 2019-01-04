using System;
using System.Collections.Generic;
using AspNetMvc.Services.Content.Pages.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Pages
{
    public interface IPageService : IWebServiceBase<Page, int, PageViewModel>
    {       
        //void Add(PageViewModel pageVm);
        //void Update(PageViewModel pageVm);    
        //void Delete(int id);
        //PageViewModel GetById(int id);
        //List<PageViewModel> GetAll();            
        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);
        PageViewModel GetByAlias(string alias);
    }
}