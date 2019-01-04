using System.Collections.Generic;
using AspNetMvc.Services.ECommerce.ProductCategories.Dtos;
using AspNetMvc.Data.Entities;
using System;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Data.Entities.ECommerce;

namespace AspNetMvc.Services.ECommerce.ProductCategories
{
    public interface IProductCategoryService : IWebServiceBase<ProductCategory, int, ProductCategoryViewModel>
    {
        PagedResult<ProductCategoryViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetAllByParentId(int? parentId);            
        List<ProductCategoryViewModel> GetHomeCategories(int top);
        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);
        //
        //void Add(ProductCategoryViewModel productCategoryVm);
        //void Update(ProductCategoryViewModel productCategoryVm);
        //void Delete(int id);
        //ProductCategoryViewModel GetById(int id);
        //List<ProductCategoryViewModel> GetAll();
        //PagedResult<ProductCategoryViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
    }
}