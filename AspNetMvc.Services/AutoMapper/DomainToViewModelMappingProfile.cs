using AutoMapper;

//using AspNetMvc.Services.System.AuditLogs;
//using AspNetMvc.Services.System.Commons;
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
using AspNetMvc.Services.ECommerce.ProductCategories.Dtos;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Services.System.Announcements.Dtos;
using AspNetMvc.Services.System.Functions.Dtos;
using AspNetMvc.Services.System.Permissions.Dtos;
using AspNetMvc.Services.System.Roles.Dtos;
using AspNetMvc.Services.System.Users.Dtos;

namespace AspNetMvc.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);
            CreateMap<Product, ProductViewModel>().MaxDepth(2);
            CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
            CreateMap<Post, PostViewModel>().MaxDepth(2);
            CreateMap<ProductTag, ProductTagViewModel>().MaxDepth(2);
            CreateMap<PostTag, PostTagViewModel>().MaxDepth(2);
            CreateMap<Tag, TagViewModel>().MaxDepth(2);
            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<Page, PageViewModel>().MaxDepth(2);
            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<Color, ColorViewModel>().MaxDepth(2);
            CreateMap<Size, SizeViewModel>().MaxDepth(2);

            //CreateMap<AppRole, AppRoleViewModel>().MaxDepth(2);
            //CreateMap<AppUser, AppUserViewModel>().ForMember(x => x.Roles, opt => opt.Ignore()).ForMember(x => x.Password, opt => opt.Ignore());
            //CreateMap<AppUser, AppUserViewModel>().MaxDepth(2);
            //CreateMap<Function, FunctionViewModel>().MaxDepth(2);
            //CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);
            //CreateMap<Product, ProductViewModel>().MaxDepth(2);
            //CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
            //CreateMap<Post, PostViewModel>().MaxDepth(2);
            //CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);
            //CreateMap<ProductQuantity, ProductQuantityViewModel>().MaxDepth(2);
            //CreateMap<ProductWishlist, ProductWishlistViewModel>().MaxDepth(2);
            //CreateMap<ProductTag, ProductTagViewModel>().MaxDepth(2);
            //CreateMap<PostTag, PostTagViewModel>().MaxDepth(2);
            //CreateMap<Tag, TagViewModel>().MaxDepth(2);
            //CreateMap<Permission, PermissionViewModel>().MaxDepth(2);
            //CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            //CreateMap<Page, PageViewModel>().MaxDepth(2);
            //CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            //CreateMap<Bill, BillViewModel>().MaxDepth(1);
            //CreateMap<BillDetail, BillDetailViewModel>().MaxDepth(1);
            //CreateMap<Color, ColorViewModel>().MaxDepth(2);
            //CreateMap<Size, SizeViewModel>().MaxDepth(2);
            //CreateMap<WholePrice, WholePriceViewModel>().MaxDepth(2);
            //CreateMap<Setting, SystemConfigViewModel>().MaxDepth(2);
            //CreateMap<Footer, FooterViewModel>().MaxDepth(2);
            //CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            //CreateMap<Menu, MenuViewModel>().MaxDepth(2);
            //CreateMap<Language, LanguageViewModel>().MaxDepth(2);
            //CreateMap<Announcement, AnnouncementViewModel>().MaxDepth(2);
            //CreateMap<AnnouncementUser, AnnouncementUserViewModel>().MaxDepth(2);
            //CreateMap<Language, LanguageViewModel>().MaxDepth(2);
            //CreateMap<Advertistment, AdvertistmentViewModel>().MaxDepth(2);
            //CreateMap<AdvertistmentPage, AdvertistmentPageViewModel>().MaxDepth(2);
            //CreateMap<AdvertistmentPosition, AdvertistmentPositionViewModel>().MaxDepth(2);
        }
    }
}