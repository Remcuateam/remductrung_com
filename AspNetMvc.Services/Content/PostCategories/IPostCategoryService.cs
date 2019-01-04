using System;
using System.Collections.Generic;
using AspNetMvc.Services.Content.PostCategories.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.PostCategories
{
    public interface IPostCategoryService : IWebServiceBase<PostCategory, int, PostCategoryViewModel>
    {
        //void Add(PostCategoryViewModel postCategoryVm);
        //void Update(PostCategoryViewModel postCategoryVm);
        //void Delete(int id);
        //PostCategoryViewModel GetById(int id);
        //List<PostCategoryViewModel> GetAll();
        //PagedResult<PostCategoryViewModel> GetAllPaging(string keyword, int page, int pageSize);
        List<PostCategoryViewModel> GetAll(string keyword);
        List<PostCategoryViewModel> GetAllByParentId(int parentId);            
        List<PostCategoryViewModel> GetHomeCategories(int top);
        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);     
    }
}