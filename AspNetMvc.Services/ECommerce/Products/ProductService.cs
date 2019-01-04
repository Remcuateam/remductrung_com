using AutoMapper;
using AutoMapper.QueryableExtensions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Constants;
using AspNetMvc.Utilities.Dtos;
using AspNetMvc.Utilities.Helpers;
using System;
using AspNetMvc.Services.Content.Tags;
using AspNetMvc.Data.Entities.ECommerce;
using AspNetMvc.Data.Entities.Content;

namespace AspNetMvc.Services.ECommerce.Products
{
    public class ProductService : WebServiceBase<Product, int, ProductViewModel>, IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IRepository<ProductCategory, int> _productCategoryRepository;
        private readonly IRepository<ProductWishlist, int> _productWishlistRepository;

        public ProductService(IRepository<Product, int> productRepository,
            IRepository<ProductTag, int> productTagRepository,
            IRepository<ProductWishlist, int> productWishlistRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<ProductCategory, int> productCategoryRepository,
            IRepository<ProductImage, int> productImageRepository,
            IRepository<ProductQuantity, int> productQuantityRepository,
            IRepository<WholePrice, int> wholePriceRepository,
            IUnitOfWork unitOfWork) : base(productRepository, unitOfWork)
        {

            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _productImageRepository = productImageRepository;
            _productQuantityRepository = productQuantityRepository;
            _wholePriceRepository = wholePriceRepository;
            _productCategoryRepository = productCategoryRepository;
            _tagRepository = tagRepository;
            _productWishlistRepository = productWishlistRepository;
        }

        public override void Add(ProductViewModel productVm)
        {
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            if (string.IsNullOrEmpty(productVm.PageAlias))
                product.PageAlias = TextHelper.ToUnsignString(productVm.Name);

            if (string.IsNullOrEmpty(productVm.Code))
            {
                var category = _productCategoryRepository.GetById(productVm.CategoryId);
                var code = category.Code + (category.CurrentIdentity + 1).ToString("0000");
                category.CurrentIdentity += 1;
                product.Code = code;
            }
            //var entity = _productRepository.Insert(product);
            //var entityId = entity.Id;
            //var entityId = Guid.NewGuid();
            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        //Id = Guid.NewGuid(),
                        //ProductId = entityId,                        
                        TagId = tagId
                    };
                    
                    _productTagRepository.Add(productTag);
                    //product.ProductTags.Add(productTag);                  
                }
            }
                _productRepository.Add(product);
        }

        public override void Update(ProductViewModel productVm)
        {
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            //var product = _productRepository.GetById(productVm.Id.Value);           

            _productTagRepository.Remove(x => x.Id == product.Id);

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag
                    {
                        //Id = Guid.NewGuid(),
                        //ProductId = product.Id,
                        TagId = tagId
                    };
                    //_productTagRepository.Insert(productTag);
                    //product.ProductTags.Add(productTag);
                }
            }
            _productRepository.Update(product);
        }

        //public override ProductViewModel GetById(Guid id)
        //{
        //    var query = (from p in _productRepository.GetAll()
        //                 join pt in _productTagRepository.GetAll() on p.Id equals pt.ProductId
        //                 join t in _tagRepository.GetAll() on pt.TagId equals t.Id
        //                 where p.Id == id && pt.ProductId == id
        //                 select new { p, pt, t }); // join product, producttag, tag           
        //    var product = (from pro in _productRepository.GetAll() where pro.Id == id select new { pro }).First();
        //    string[] tags = product.pro.Tags.Split(',');
        //    var tagId = "";
        //    foreach (string tagitem in tags)
        //    {
        //        tagId = TextHelper.ToUnsignString(tagitem);
        //        var productTag = _productTagRepository.FirstOrDefault(v => v.TagId == tagId && v.ProductId == product.pro.Id);
        //        Mapper.Map<Tag, TagViewModel>(_tagRepository.GetById(tagId)); // tao moi chu ko sua
        //        Mapper.Map<ProductTag, ProductTagViewModel>(_productTagRepository.GetById(productTag.Id)); // tao moi chu ko sua
        //    }
        //    var pageAlias = TextHelper.ToUnsignString(product.pro.Name);
        //    var model = new ProductViewModel() // tao them 1 cai product, ko sua
        //    {
        //        Name = product.pro.Name,
        //        PageAlias = pageAlias,
        //        CategoryId = product.pro.CategoryId,
        //        PageTitle = product.pro.PageTitle,
        //        MetaDescription = product.pro.MetaDescription,
        //        Tags = product.pro.Tags,
        //        Price = product.pro.Price,
        //        OriginalPrice = product.pro.OriginalPrice,
        //        PromotionPrice = product.pro.PromotionPrice,
        //        UpdatedDate = product.pro.UpdatedDate,
        //        Status = product.pro.Status
        //    };
        //    return model;
        //}


        //public override List<ProductViewModel> GetAll()
        //{
        //    var query = (from pc in _productCategoryRepository.GetAll()
        //                 join p in _productRepository.GetAll()
        //                     on pc.Id equals p.CategoryId
        //                 select new { p, pc });

        //    var model = query.OrderByDescending(x => x.p.CreatedDate)
        //        .Select(x => new ProductViewModel()
        //        {
        //            Name = x.p.Name,
        //            Id = x.p.Id,
        //            CategoryId = x.p.CategoryId,
        //            CategoryName = x.pc.Name,
        //            Price = x.p.Price,
        //            ThumbnailImage = x.p.ThumbnailImage,
        //            DateCreated = x.p.DateCreated,
        //            Status = x.p.Status
        //        }).ToList();

        //    return model;
        //}

        //public override void Delete(Guid id)
        //{
        //    _productRepository.Delete(id);
        //}

        //public override ProductViewModel GetById(Guid id)
        //{
        //    return Mapper.Map<Product, ProductViewModel>(_productRepository.GetById(id));
        //}

        //public override List<ProductViewModel> GetAll()
        //{
        //    return _productRepository.GetAll().OrderBy(c => c.ProductTags)
        //    return _productRepository.FindAll(c => c.ProductCategory, c => c.ProductTags)
        //        .ProjectTo<ProductViewModel>().ToList();
        //}

        //public PagedResult<ProductViewModel> GetAllPaging(string keyword, int pageSize, int page = 1)
        //{
        //    var query = _productRepository.FindAll();
        //    if (!string.IsNullOrEmpty(keyword))
        //        query = query.Where(x => x.Name.Contains(keyword));
        //    int totalRow = query.Count();
        //    var data = query.OrderByDescending(x => x.CreatedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize);
        //    var paginationSet = new PagedResult<ProductViewModel>()
        //    {
        //        Results = data.ProjectTo<ProductViewModel>().ToList(),
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize,
        //    };
        //    return paginationSet;
        //}

        public PagedResult<ProductViewModel> GetAllPaging(int categoryId, string keyword, int page, int pageSize, string sortBy)
        {
            var query = _productRepository.GetAll().Where(c => c.Status == Status.Actived);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword) || x.Code.Contains(keyword));

            if (categoryId.ToString()!=null)
                //if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);

            int totalRow = query.Count();
            switch (sortBy)
            {
                case "price":
                    query = query.OrderByDescending(x => x.Price);
                    break;

                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "lastest":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<ProductViewModel> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.CategoryId == categoryId);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in _productRepository.GetAll()
                        join pt in _productTagRepository.GetAll()
                        on p.Id equals pt.ProductId
                        where pt.TagId == tagId
                        select p;
            totalRow = query.Count();

            var model = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ProjectTo<ProductViewModel>();
            return model.ToList();
        }

        public PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize)
        {
            //var query = _productWishlistRepository.FindAll(c => c.UserId == userId, i => i.Product).Select(x => x.Product);
            var query = _productWishlistRepository.GetAll().Where(c => c.UserId == userId);
            int totalRow = query.Count();

            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public List<ProductViewModel> GetListProduct(string keyword)
        {
            IQueryable<ProductViewModel> query;
            if (!string.IsNullOrEmpty(keyword))
                query = _productRepository.GetAll().Where(x => x.Name.Contains(keyword)).ProjectTo<ProductViewModel>();
            else
                query = _productRepository.GetAll().ProjectTo<ProductViewModel>();
            return query.ToList();
        }

        public List<string> GetListProductByName(string name)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(name)).Select(y => y.Name).ToList();
        }

        public List<ProductViewModel> GetLastest(int top)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived).OrderByDescending(x => x.CreatedDate)
                .Take(top).ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.HotFlag == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(top)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public List<ProductViewModel> GetReatedProducts(int id, int top)
        {
            var product = _productRepository.GetById(id);
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived
                && x.Id != id && x.CategoryId == product.CategoryId)
            .OrderByDescending(x => x.CreatedDate)
            .Take(top)
            .ProjectTo<ProductViewModel>()
            .ToList();
        }

        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _productRepository.GetAll().Where(x => x.PromotionPrice != null)
                .OrderByDescending(x => x.UpdatedDate)
                .Take(top)
                .ProjectTo<ProductViewModel>().ToList();
        }

        public void IncreaseView(int id)
        {
            var product = _productRepository.GetById(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
        }

        public List<TagViewModel> GetListTagByProductId(int id)
        {
            return _productTagRepository.GetAll(x => x.ProductId == id, c => c.Tag)
                .Select(y => y.Tag)
                .ProjectTo<TagViewModel>()
                .ToList();           
        }       

        public List<TagViewModel> GetListProductTag(string searchText)
        {
            return _tagRepository.GetAll(x => x.Type == CommonConstants.ProductTag
            && searchText.Contains(x.Name)).ProjectTo<TagViewModel>().ToList();
        }

        public TagViewModel GetTag(string tagId)
        {
            return Mapper.Map<Tag, TagViewModel>(_tagRepository.Single(x => x.Id == tagId));
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            //return _productImageRepository.FindAll(x => x.ProductId == productId)
            return _productImageRepository.GetAll().Where(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>().ToList();
        }

        public bool SellProduct(int productId, int quantity)
        {
            //var product = _productRepository.FindById(productId);
            var product = _productRepository.GetById(productId);

            //if (product.Quantity < quantity)
            //    return false;
            //product.Quantity -= quantity;

            return true;
        }

        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            //_productQuantityRepository.RemoveMultiple(_productQuantityRepository.FindAll(x => x.ProductId == productId).ToList());
            _productQuantityRepository.Remove(x => x.ProductId == productId);
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            //return _productQuantityRepository.FindAll(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
            return _productQuantityRepository.GetAll().Where(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.Remove(x => x.ProductId == productId);
            //_wholePriceRepository.RemoveMultiple(_wholePriceRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
                });
            }
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            return _wholePriceRepository.GetAll().Where(x => x.ProductId == productId).ProjectTo<WholePriceViewModel>().ToList();
        }

        public void ImportExcel(string filePath, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();
                    product.CategoryId = categoryId;
                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    product.Description = workSheet.Cells[i, 2].Value.ToString();
                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var originalPrice);
                    product.OriginalPrice = originalPrice;
                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                    product.Price = price;
                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var promotionPrice);

                    product.PromotionPrice = promotionPrice;
                    product.Content = workSheet.Cells[i, 6].Value.ToString();
                    product.MetaKeywords = workSheet.Cells[i, 7].Value.ToString();

                    product.MetaDescription = workSheet.Cells[i, 8].Value.ToString();
                    bool.TryParse(workSheet.Cells[i, 9].Value.ToString(), out var hotFlag);
                    product.HotFlag = hotFlag;
                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                    product.HomeFlag = homeFlag;

                    product.Status = Status.Actived;

                    _productRepository.Add(product);
                }
            }
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.Remove(x => x.ProductId == productId);
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
        }

     

        //public override List<ProductViewModel> GetAll()
        //{
        //    var query = (from pc in _productCategoryRepository.GetAll()
        //                 join p in _productRepository.GetAll()
        //                     on pc.Id equals p.CategoryId
        //                 select new { p, pc });

        //    var model = query.OrderByDescending(x => x.p.CreatedDate)
        //        .Select(x => new ProductViewModel()
        //        {
        //            Name = x.p.Name,
        //            Id = x.p.Id,
        //            CategoryId = x.p.CategoryId,
        //            Name = x.pc.Name,
        //            Price = x.p.Price,
        //            Image = x.p.Image,
        //            CreatedDate = x.p.CreatedDate,
        //            Status = x.p.Status
        //        }).ToList();

        //    return model;
        //}
    }
}