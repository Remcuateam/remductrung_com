using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.ECommerce.ProductCategories.Dtos;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Helpers;
using System;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Data.Entities.ECommerce;

namespace AspNetMvc.Services.ECommerce.ProductCategories
{
    public class ProductCategoryService : WebServiceBase<ProductCategory, int, ProductCategoryViewModel>, 
        IProductCategoryService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<ProductCategory, int> _productCategoryRepository;
      
        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository,
            IRepository<Product, int> productRepository,
            IUnitOfWork unitOfWork) : base(productCategoryRepository, unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository; 
        }

        public override void Add(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.PageAlias))
                productCategoryVm.PageAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
        }

        public override void Update(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.PageAlias))
                productCategoryVm.PageAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);

            _productCategoryRepository.Update(productCategory);
        }

        //public override ProductCategoryViewModel GetById(Guid id)
        //{

        //    var query = (from pc in _productCategoryRepository.GetAll()
        //                 join p in _productRepository.GetAll()
        //                     on pc.Id equals p.CategoryId
        //                 where pc.Id == id && p.CategoryId == id
        //                 select new { p });

        //    var productCategory = (from pcat in _productCategoryRepository.GetAll() where pcat.Id == id select new { pcat }).First();


        //    var productlist = query.Select(x => new ProductViewModel()
        //    {
        //        Name = x.p.Name,
        //        //Id = x.p.Id,
        //        CategoryId = x.p.CategoryId,
        //        PageAlias = x.p.PageAlias,
        //        Description = x.p.Description,
        //        Image = x.p.Image,
        //        Content = x.p.Content,
        //        ViewCount = x.p.ViewCount,
        //        Tags = x.p.Tags,
        //        Unit = x.p.Unit,
        //        HomeFlag = x.p.HomeFlag,
        //        HotFlag = x.p.HotFlag,
        //        Quantity = x.p.Quantity,
        //        Price = x.p.Price,
        //        OriginalPrice = x.p.OriginalPrice,
        //        PromotionPrice = x.p.PromotionPrice,
        //        Status = x.p.Status,
        //        PageTitle = x.p.PageTitle,
        //        MetaDescription = x.p.MetaDescription,
        //        MetaKeywords = x.p.MetaKeywords
        //    }).ToList();

        //    var model = new ProductCategoryViewModel()
        //    {
        //        Name = productCategory.pcat.Name,
        //        Id = productCategory.pcat.Id,
        //        CreatedDate = productCategory.pcat.CreatedDate,
        //        Products = productlist,
        //        Status = productCategory.pcat.Status
        //    };

        //    return model;
        //}
        //public override void Delete(Guid id)
        //{
        //    _productCategoryRepository.Delete(id);
        //}

        //public override ProductCategoryViewModel GetById(Guid id)
        //{
        //    return Mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.GetById(id));
        //}

        //public override List<ProductCategoryViewModel> GetAll()
        //{
        //    return _productCategoryRepository.GetAll().OrderBy(x => x.ParentId)
        //        .ProjectTo<ProductCategoryViewModel>()
        //        .ToList();
        //}

        //public PagedResult<ProductCategoryViewModel> GetAllPaging(string keyword, int pageSize, int page = 1)
        //{
        //    var query = _productCategoryRepository.FindAll();
        //    if (!string.IsNullOrEmpty(keyword))
        //        query = query.Where(x => x.Name.Contains(keyword));
        //    int totalRow = query.Count();
        //    var data = query.OrderByDescending(x => x.CreatedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize);
        //    var paginationSet = new PagedResult<ProductCategoryViewModel>()
        //    {
        //        Results = data.ProjectTo<ProductCategoryViewModel>().ToList(),
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize,
        //    };
        //    return paginationSet;
        //}
        public PagedResult<ProductCategoryViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _productCategoryRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword));

            int totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize)
               .Take(pageSize);

            var data = query.ProjectTo<ProductCategoryViewModel>().ToList();
            var paginationSet = new PagedResult<ProductCategoryViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetAll().Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
            return _productCategoryRepository.GetAll().OrderBy(x => x.ParentId)
                .ProjectTo<ProductCategoryViewModel>()
                .ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int? parentId)
        {
            return _productCategoryRepository.GetAll().Where(x => x.Status == Status.Actived && x.ParentId == parentId)
                .ProjectTo<ProductCategoryViewModel>()
                .ToList();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository.GetAll().Where(x => x.HomeFlag == true)
                .OrderBy(x => x.HomeOrder).Take(top).ProjectTo<ProductCategoryViewModel>();
            var categories = query.ToList();
            //foreach (var category in categories)
            //{
                //category.Products = _productRepository
                //    .GetAll().Where(x => x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.CreatedDate)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            //}
            return categories;
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            //Update parent id for source
            var category = _productCategoryRepository.GetById(sourceId);
            category.ParentId = targetId;
            _productCategoryRepository.Update(category);

            //Get all sibling
            var sibling = _productCategoryRepository.GetAll().Where(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _productCategoryRepository.GetById(sourceId);
            var target = _productCategoryRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }              
    }
}