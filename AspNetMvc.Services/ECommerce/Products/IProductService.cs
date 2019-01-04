using System;
using System.Collections.Generic;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.ECommerce;
using AspNetMvc.Services.Content.Tags;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.ECommerce.Products
{
    public interface IProductService : IWebServiceBase<Product, int, ProductViewModel>
    {
        //void Add(ProductViewModel productVm);
        //void Update(ProductViewModel productVm);
        //void Delete(int id);
        //ProductViewModel GetById(int id);
        //List<ProductViewModel> GetAll();
        //PagedResult<ProductViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
        PagedResult<ProductViewModel> GetAllPaging(int categoryId, string keyword, int page, int pageSize, string sortBy);
        List<ProductViewModel> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);
        PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize);
        List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListProduct(string keyword);
        List<string> GetListProductByName(string name);
        List<ProductViewModel> GetLastest(int top);
        List<ProductViewModel> GetHotProduct(int top);
        List<ProductViewModel> GetReatedProducts(int id, int top);
        List<ProductViewModel> GetUpsellProducts(int top);
        void IncreaseView(int id);
        List<TagViewModel> GetListTagByProductId(int id);
        List<TagViewModel> GetListProductTag(string searchText);
        TagViewModel GetTag(string tagId);
        List<ProductImageViewModel> GetImages(int productId);
        bool SellProduct(int productId, int quantity);
        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);
        List<ProductQuantityViewModel> GetQuantities(int productId);
        void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);
        List<WholePriceViewModel> GetWholePrices(int productId);
        void ImportExcel(string filePath, int categoryId);
        void AddImages(int productId, string[] images);                              
    }
}