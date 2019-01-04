﻿using AutoMapper;
using AspNetMvc.Data.Entities.Advertistment;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Entities.ECommerce;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Services.Advs.Dtos;
using AspNetMvc.Services.Content.Contacts.Dtos;
using AspNetMvc.Services.Content.Feedbacks.Dtos;
using AspNetMvc.Services.Content.Footers.Dtos;
using AspNetMvc.Services.Content.Pages.Dtos;
using AspNetMvc.Services.Content.PostCategories.Dtos;
using AspNetMvc.Services.Content.Posts.Dtos;
using AspNetMvc.Services.Content.Slides.Dtos;
using AspNetMvc.Services.Content.Tags;
using AspNetMvc.Services.ECommerce.Bills.Dtos;
using AspNetMvc.Services.ECommerce.ProductCategories.Dtos;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Services.System.Functions.Dtos;
using AspNetMvc.Services.System.Permissions.Dtos;
using AspNetMvc.Services.System.Roles.Dtos;
using AspNetMvc.Services.System.Users.Dtos;

namespace AspNetMvc.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
               .ConstructUsing(c => new ProductCategory(c.ParentId, c.Code, c.Name, c.PageAlias, c.Description,
               c.Image, c.HomeFlag, c.HomeOrder, c.SortOrder, c.Status, c.RelCanonical, c.PageTitle, c.MetaKeywords, c.MetaDescription));

            CreateMap<ProductViewModel, Product>()
              .ConstructUsing(c => new Product(c.CategoryId, c.Code, c.Name, c.PageAlias, c.Description, c.Image, c.Content, c.ViewCount, c.Tags,
              c.Unit, c.HomeFlag, c.HotFlag, c.Quantity, c.Price, c.OriginalPrice, c.PromotionPrice, c.Status, c.PageTitle, c.MetaDescription, c.MetaKeywords));

            CreateMap<PostCategoryViewModel, PostCategory>()
               .ConstructUsing(c => new PostCategory(c.Id, c.ParentId, c.CurrentIdentity, c.CategoryName, c.PageAlias, c.Description, c.CategoryImage, c.HomeFlag, c.HomeOrder,
               c.SortOrder, c.Status, c.RelCanonical, c.PageTitle, c.MetaKeywords, c.MetaDescription));

            CreateMap<PostViewModel, Post>()
             .ConstructUsing(c => new Post(c.Id, c.CategoryId, c.Name, c.PageAlias, c.Description, c.Image, c.Content, c.Tags, c.HomeFlag,
             c.HotFlag, c.ViewCount, c.Status, c.PageTitle, c.MetaDescription, c.MetaKeywords));



           // CreateMap<AppUserViewModel, AppUser>()
           //  .ConstructUsing(c => new AppUser(c.FullName, c.UserName, c.Email, c.PhoneNumber, c.Address, c.Gender, c.Avatar, c.Status));

           // CreateMap<AppRoleViewModel, AppRole>()
           // .ConstructUsing(c => new AppRole(c.Name, c.Description));

           // CreateMap<ProductCategoryViewModel, ProductCategory>()
           //     .ConstructUsing(c => new ProductCategory(c.ParentId, c.Code, c.Name, c.PageAlias, c.Description,
           //     c.Image, c.HomeFlag, c.HomeOrder, c.SortOrder, c.Status, c.RelCanonical, c.PageTitle, c.MetaKeywords, c.MetaDescription));
           // .ForMember("Products", conf => conf.Ignore());

           // CreateMap<ProductViewModel, Product>()
           //   .ConstructUsing(c => new Product(c.CategoryId, c.Code, c.Name, c.PageAlias, c.Description, c.Image, c.Content, c.ViewCount, c.Tags,
           //   c.Unit, c.HomeFlag, c.HotFlag, c.Quantity, c.Price, c.OriginalPrice, c.PromotionPrice, c.Status, c.PageTitle, c.MetaDescription, c.MetaKeywords));

           // CreateMap<PostCategoryViewModel, PostCategory>()
           //    .ConstructUsing(c => new PostCategory(c.Id, c.ParentId, c.CurrentIdentity, c.CategoryName, c.PageAlias, c.Description, c.CategoryImage, c.HomeFlag, c.HomeOrder,
           //    c.SortOrder, c.Status, c.RelCanonical, c.PageTitle, c.MetaKeywords, c.MetaDescription));
           // .ForMember("Post", conf => conf.Ignore());

           // CreateMap<PostViewModel, Post>()
           //   .ConstructUsing(c => new Post(c.Id, c.CategoryId, c.Name, c.PageAlias, c.Description, c.Image, c.Content, c.Tags, c.HomeFlag,
           //   c.HotFlag, c.ViewCount, c.Status, c.PageTitle, c.MetaDescription, c.MetaKeywords));

           // CreateMap<ProductImageViewModel, ProductImage>()
           //  .ConstructUsing(c => new ProductImage(c.Id, c.ProductId, c.Path, c.Caption, c.SortOrder));

           // CreateMap<ProductQuantityViewModel, ProductQuantity>()
           //    .ConstructUsing(c => new ProductQuantity(c.SizeId, c.ColorId, c.ProductId));

           // CreateMap<ProductWishlistViewModel, ProductWishlist>()
           //    .ConstructUsing(c => new ProductWishlist(c.Id, c.UserId, c.ProductId));

           // CreateMap<ProductTagViewModel, ProductTag>()
           //    .ConstructUsing(c => new ProductTag(c.ProductId, c.TagId));

           // CreateMap<TagViewModel, Tag>()
           //    .ConstructUsing(c => new Tag(c.Name, c.Type));

           // CreateMap<FunctionViewModel, Function>()
           //    .ConstructUsing(c => new Function(c.Name, c.Url, c.ParentId, c.CssClass, c.SortOrder, c.Status));

           // CreateMap<PermissionViewModel, Permission>()
           //.ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));

           // CreateMap<SlideViewModel, Slide>()
           //   .ConstructUsing(c => new Slide(c.Id, c.Name, c.Image, c.Url, c.SortOrder, c.Status, c.GroupAlias));

           // CreateMap<PageViewModel, Page>()
           //  .ConstructUsing(c => new Page(c.Id, c.Name, c.PageAlias, c.Image, c.Content, c.Status, c.PageTitle, c.MetaDescription, c.MetaKeywords));

           // CreateMap<ContactViewModel, Contact>()
           //   .ConstructUsing(c => new Contact(c.Id, c.Name, c.Phone, c.Email, c.Website, c.Address, c.Other, c.Lng, c.Lat, c.Status));

           // CreateMap<BillViewModel, Bill>()
           //   .ConstructUsing(c => new Bill(c.Id, c.CustomerId, c.CustomerName, c.CustomerMobile, c.CustomerAddress, c.CustomerMessage, c.CustomerFacebook,
           //   c.ShippingFee, c.PaymentMethod, c.BillStatus, c.Status));

           // CreateMap<BillDetailViewModel, BillDetail>()
           //   .ConstructUsing(c => new BillDetail(c.Id, c.BillId, c.ProductId, c.Quantity, c.Price, c.ColorId, c.SizeId));

           // CreateMap<ColorViewModel, Color>()
           //  .ConstructUsing(c => new Color(c.Id, c.Name, c.Code));

           // CreateMap<SizeViewModel, Size>()
           //  .ConstructUsing(c => new Size(c.Id, c.Width, c.Height));

           // CreateMap<WholePriceViewModel, WholePrice>()
           //    .ConstructUsing(c => new WholePrice(c.Id, c.ProductId, c.FromQuantity, c.ToQuantity, c.Price));

           // CreateMap<SystemConfigViewModel, Setting>()
           //   .ConstructUsing(c => new Setting(c.Id, c.Name, c.TextValue, c.IntegerValue, c.BooleanValue, c.DateValue, c.DecimalValue,
           //   c.Description, c.UniqueCode, c.Status));

           // CreateMap<FooterViewModel, Footer>()
           //  .ConstructUsing(c => new Footer(c.Content, c.Status));

           // CreateMap<FeedbackViewModel, Feedback>()
           //    .ConstructUsing(c => new Feedback(c.Id, c.Name, c.Phone, c.Email, c.Address, c.Message, c.Status));

           // CreateMap<MenuViewModel, Menu>()
           //    .ConstructUsing(c => new Menu(c.ParentId, c.Name, c.Url, c.Css, c.SortOrder, c.Status));

           // CreateMap<LanguageViewModel, Language>()
           //    .ConstructUsing(c => new Language(c.Name, c.IsDefault, c.Resources, c.Status));

           // CreateMap<AnnouncementViewModel, Announcement>()
           //    .ConstructUsing(c => new Announcement(c.UserId, c.Title, c.Content, c.Status));

           // CreateMap<AnnouncementUserViewModel, AnnouncementUser>()
           //    .ConstructUsing(c => new AnnouncementUser(c.AnnouncementId, c.UserId, c.HasRead));

           // CreateMap<AdvertistmentViewModel, Advertistment>()
           //    .ConstructUsing(c => new Advertistment(c.PositionId, c.Name, c.Description, c.Image, c.Url, c.SortOrder, c.Status));

           // CreateMap<AdvertistmentPageViewModel, AdvertistmentPage>()
           //    .ConstructUsing(c => new AdvertistmentPage(c.Name, c.UniqueCode));

           // CreateMap<AdvertistmentPositionViewModel, AdvertistmentPosition>()
           //    .ConstructUsing(c => new AdvertistmentPosition(c.PageId, c.Name));
        }
    }
}