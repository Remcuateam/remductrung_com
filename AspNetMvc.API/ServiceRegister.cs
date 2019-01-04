using Microsoft.Extensions.DependencyInjection;
using AspNetMvc.Services.Content.Contacts;
using AspNetMvc.Services.Content.Feedbacks;
using AspNetMvc.Services.Content.Pages;
using AspNetMvc.Services.Content.Posts;
using AspNetMvc.Services.Content.Slides;
using AspNetMvc.Services.ECommerce.ProductCategories;
using AspNetMvc.Services.ECommerce.Products;
using AspNetMvc.Services.System.Commons;
using AspNetMvc.Services.System.Functions;
using AspNetMvc.Services.System.Roles;
using AspNetMvc.Services.System.Users;

namespace AspNetMvc.API
{
    public class ServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IReportService, ReportService>();
        }
    }
}