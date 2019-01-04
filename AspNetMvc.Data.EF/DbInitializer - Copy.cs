using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Advertistment;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Entities.ECommerce;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Utilities.Constants;

namespace AspNetMvc.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole() { Name = "Admin", NormalizedName = "Admin", Description = "Admin" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Ban lãnh đạo", NormalizedName = "Ban lãnh đạo", Description = "Ban lãnh đạo" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Quản lý", NormalizedName = "Quản lý", Description = "Quản lý" });
                await _roleManager.CreateAsync(new AppRole() { Name = "Nhân viên", NormalizedName = "Nhân viên", Description = "Nhân viên" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Biên tập viên", NormalizedName = "Biên tập viên", Description = "Biên tập viên" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Cộng tác viên", NormalizedName = "Cộng tác viên", Description = "Cộng tác viên" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Nhân viên tập sự", NormalizedName = "Nhân viên tập sự", Description = "Nhân viên tập sự" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Thực tập viên", NormalizedName = "Thực tập viên", Description = "Thực tập viên" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Khách hàng", NormalizedName = "Khách hàng", Description = "Khách hàng" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Giám sát", NormalizedName = "Giám sát", Description = "Giám sát" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Trưởng phòng", NormalizedName = "Trưởng phòng", Description = "Trưởng phòng" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Phó phòng", NormalizedName = "Phó phòng", Description = "Phó phòng" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Giám đốc", NormalizedName = "Giám đốc", Description = "Giám đốc" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Đối tác", NormalizedName = "Đối tác", Description = "Đối tác" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Chủ tịch hội đồng quản trị", NormalizedName = "Chủ tịch hội đồng quản trị", Description = "Chủ tịch hội đồng quản trị" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Điều hành", NormalizedName = "Điều hành", Description = "Điều hành" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Quản trị Web", NormalizedName = "Quản trị Web", Description = "Quản trị Web" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Sáng lập viên", NormalizedName = "Sáng lập viên", Description = "Sáng lập viên" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Trực ban", NormalizedName = "Trực ban", Description = "Trực ban" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Quản trị mạng", NormalizedName = "Quản trị mạng", Description = "Quản trị mạng" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Trưởng nhóm", NormalizedName = "Trưởng nhóm", Description = "Trưởng nhóm" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Kinh doanh", NormalizedName = "Kinh doanh", Description = "Kinh doanh" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Marketing", NormalizedName = "Marketing", Description = "Marketing" });
                await _roleManager.CreateAsync(new AppRole() {  Name = "Cổ đông", NormalizedName = "Cổ đông", Description = "Cổ đông" });
            }

            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser() {  UserName = "admin", FullName = "Administrator", Email = "admin@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user = await _userManager.FindByNameAsync("admin"); await _userManager.AddToRoleAsync(user, "Admin");

                await _userManager.CreateAsync(new AppUser() {  UserName = "rico", FullName = "rico", Email = "rico@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user2 = await _userManager.FindByNameAsync("rico"); await _userManager.AddToRoleAsync(user2, "Admin");

                await _userManager.CreateAsync(new AppUser() {  UserName = "micral", FullName = "micral", Email = "micral@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user3 = await _userManager.FindByNameAsync("micral"); await _userManager.AddToRoleAsync(user3, "Admin");

                await _userManager.CreateAsync(new AppUser() {  UserName = "ceo", FullName = "CEO", Email = "ceo@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user4 = await _userManager.FindByNameAsync("ceo"); await _userManager.AddToRoleAsync(user4, "Ban lãnh đạo");

                await _userManager.CreateAsync(new AppUser() {  UserName = "staff", FullName = "staff", Email = "staff@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user5 = await _userManager.FindByNameAsync("staff"); await _userManager.AddToRoleAsync(user5, "Quản lý");

                await _userManager.CreateAsync(new AppUser() {  UserName = "employee", FullName = "employee", Email = "employee@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user6 = await _userManager.FindByNameAsync("employee"); await _userManager.AddToRoleAsync(user6, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user7", FullName = "user7", Email = "user7@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user7 = await _userManager.FindByNameAsync("user7"); await _userManager.AddToRoleAsync(user7, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user8", FullName = "user8", Email = "user8@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user8 = await _userManager.FindByNameAsync("user8"); await _userManager.AddToRoleAsync(user8, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user9", FullName = "user9", Email = "user9@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user9 = await _userManager.FindByNameAsync("user9"); await _userManager.AddToRoleAsync(user9, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user10", FullName = "user10", Email = "user10@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user10 = await _userManager.FindByNameAsync("user10"); await _userManager.AddToRoleAsync(user10, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user11", FullName = "user11", Email = "user11@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user11 = await _userManager.FindByNameAsync("user11"); await _userManager.AddToRoleAsync(user11, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user12", FullName = "user12", Email = "user12@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user12 = await _userManager.FindByNameAsync("user12"); await _userManager.AddToRoleAsync(user12, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user13", FullName = "user13", Email = "user13@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user13 = await _userManager.FindByNameAsync("user13"); await _userManager.AddToRoleAsync(user13, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user14", FullName = "user14", Email = "user14@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user14 = await _userManager.FindByNameAsync("user14"); await _userManager.AddToRoleAsync(user14, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user15", FullName = "user15", Email = "user15@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user15 = await _userManager.FindByNameAsync("user15"); await _userManager.AddToRoleAsync(user15, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user16", FullName = "user16", Email = "user16@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user16 = await _userManager.FindByNameAsync("user16"); await _userManager.AddToRoleAsync(user16, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user17", FullName = "user17", Email = "user17@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user17 = await _userManager.FindByNameAsync("user17"); await _userManager.AddToRoleAsync(user17, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user18", FullName = "user18", Email = "user18@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user18 = await _userManager.FindByNameAsync("user18"); await _userManager.AddToRoleAsync(user18, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user19", FullName = "user19", Email = "user19@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user19 = await _userManager.FindByNameAsync("user19"); await _userManager.AddToRoleAsync(user19, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user20", FullName = "user20", Email = "user20@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user20 = await _userManager.FindByNameAsync("user20"); await _userManager.AddToRoleAsync(user20, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user21", FullName = "user21", Email = "user21@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user21 = await _userManager.FindByNameAsync("user21"); await _userManager.AddToRoleAsync(user21, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user22", FullName = "user22", Email = "user22@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user22 = await _userManager.FindByNameAsync("user22"); await _userManager.AddToRoleAsync(user22, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user23", FullName = "user23", Email = "user23@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user23 = await _userManager.FindByNameAsync("user23"); await _userManager.AddToRoleAsync(user23, "Nhân viên");

                await _userManager.CreateAsync(new AppUser() {  UserName = "user24", FullName = "user24", Email = "user24@gmail.com", CreatedDate = DateTime.Now, Status = Status.Actived }, "hoilamgi");
                var user24 = await _userManager.FindByNameAsync("user24"); await _userManager.AddToRoleAsync(user24, "Nhân viên");
            }

            if (!_context.Functions.Any())
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "Hệ thống",ParentId = null,SortOrder = 1,Status = Status.Actived,Url = "/",CssClass = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Nhóm",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Actived,Url = "/admin/role/index",CssClass = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id = "USER", Name = "Người dùng",ParentId = "SYSTEM",SortOrder =3,Status = Status.Actived,Url = "/admin/user/index",CssClass = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Nhật ký",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Actived,Url = "/admin/activity/index",CssClass = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Lỗi",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Actived,Url = "/admin/error/index",CssClass = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Cấu hình",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Actived,Url = "/admin/setting/index",CssClass = "fa-home"  },

                    new Function() {Id = "ECOMMERCE",Name = "Sản phẩm",ParentId = null,SortOrder = 2,Status = Status.Actived,Url = "/",CssClass = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = "ECOMMERCE",SortOrder =1,Status = Status.Actived,Url = "/admin/productcategory/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = "ECOMMERCE",SortOrder = 2,Status = Status.Actived,Url = "/admin/product/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Hóa đơn",ParentId = "ECOMMERCE",SortOrder = 3,Status = Status.Actived,Url = "/admin/bill/index",CssClass = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Nội dung",ParentId = null,SortOrder = 3,Status = Status.Actived,Url = "/",CssClass = "fa-table"  },
                    new Function() {Id = "POST_CATEGORY",Name = "Danh mục",ParentId = "CONTENT",SortOrder =1,Status = Status.Actived,Url = "/admin/postcategory/index",CssClass = "fa-table"  },
                    new Function() {Id = "POST",Name = "Bài viết",ParentId ="CONTENT",SortOrder = 2,Status = Status.Actived,Url = "/admin/post/index",CssClass = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Trang",ParentId = "CONTENT",SortOrder = 3,Status = Status.Actived,Url = "/admin/page/index",CssClass = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Tiện ích",ParentId = null,SortOrder = 4,Status = Status.Actived,Url = "/",CssClass = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Actived,Url = "/admin/footer/index",CssClass = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Phản hồi",ParentId = "UTILITY",SortOrder = 2,Status = Status.Actived,Url = "/admin/feedback/index",CssClass = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Thông báo",ParentId = "UTILITY",SortOrder = 3,Status = Status.Actived,Url = "/admin/announcement/index",CssClass = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Liên hệ",ParentId = "UTILITY",SortOrder = 4,Status = Status.Actived,Url = "/admin/contact/index",CssClass = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Actived,Url = "/admin/slide/index",CssClass = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Quảng cáo",ParentId = "UTILITY",SortOrder = 6,Status = Status.Actived,Url = "/admin/advertistment/index",CssClass = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Báo cáo",ParentId = null,SortOrder = 5,Status = Status.Actived,Url = "/",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Báo cáo doanh thu",ParentId = "REPORT",SortOrder = 1,Status = Status.Actived,Url = "/admin/report/revenues",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Báo cáo truy cập",ParentId = "REPORT",SortOrder = 2,Status = Status.Actived,Url = "/admin/report/visitor",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Báo cáo độc giả",ParentId = "REPORT",SortOrder = 3,Status = Status.Actived,Url = "/admin/report/reader",CssClass = "fa-bar-chart-o"  },
                });
            }

            if (_context.Contacts.Count(x => x.Id == CommonConstants.DefaultContactId) == 0)
            {
                _context.Contacts.Add(new Contact()
                {
                    Id = CommonConstants.DefaultContactId,
                    Name = "ABC",
                    Phone = "0900 000 000",
                    Email = "abc@gmail.com",
                    Website = "/",
                    Address = "Hanoi",
                    Other = "Khác",
                    Lng = 21.0000000,
                    Lat = 105.000000,
                    Status = Status.Actived,                    
                });
            }

            if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                _context.Footers.Add(new Footer()
                {
                    Id = CommonConstants.DefaultFooterId,
                    Content = content,
                    Status = Status.Actived
                });
            }

            if (_context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color() {Name="Black", Code="#000000" },
                    new Color() {Name="White", Code="#FFFFFF"},
                    new Color() {Name="Red", Code="#ff0000" },
                    new Color() {Name="Blue", Code="#1000ff" },
                };
                _context.Colors.AddRange(listColor);
            }

            //if (!_context.AdvertistmentPages.Any())
            //{
            //    List<AdvertistmentPage> pages = new List<AdvertistmentPage>()
            //    {
            //        new AdvertistmentPage() { Id = "home", UniqueCode="home", Name="Trang chủ"},
            //        new AdvertistmentPage() { Id ="product-category", UniqueCode ="product-cate", Name="Danh mục sản phẩm" },
            //        new AdvertistmentPage() { Id = "product-detail", UniqueCode ="product-detail", Name="Chi tiết sản phẩm"},
            //    };
            //    _context.AdvertistmentPages.AddRange(pages);
            //}

            //if (!_context.AdvertistmentPages.Any())
            //{
            //    List<AdvertistmentPage> pages = new List<AdvertistmentPage>()
            //    {
            //         new AdvertistmentPage() {Id="home", UniqueCode="home", Name="Home",
            //             AdvertistmentPositions = new List<AdvertistmentPosition>(){
            //            new AdvertistmentPosition(){Id="home-left",Name="Trang chủ bên trái ",
            //            Advertistments = new List<Advertistment>()
            //            {
            //                new Advertistment(){Name = "Trang chủ bên trái 1",Description = "Trang chủ bên trái 1", Image = "/", Url = "/", SortOrder = 1,  Status = Status.Actived},
            //                new Advertistment(){Name = "Trang chủ bên trái 2",Description = "Trang chủ bên trái 2", Image = "/", Url = "/", SortOrder = 2,  Status = Status.Actived},
            //                new Advertistment(){Name = "Trang chủ bên trái 3",Description = "Trang chủ bên trái 3", Image = "/", Url = "/", SortOrder = 3,  Status = Status.Actived}
            //            }
            //            }
            //        } },
            //        new AdvertistmentPage() {Id="product-category", UniqueCode ="product-category", Name="Product category" ,
            //            AdvertistmentPositions = new List<AdvertistmentPosition>(){
            //            new AdvertistmentPosition(){Id="product-category-left", Name="Danh mục sản phẩm bên trái",
            //            Advertistments = new List<Advertistment>()
            //            {
            //                new Advertistment(){Name = "Danh mục sản phẩm bên trái 1",Description = "Danh mục sản phẩm bên trái 1", Image = "/", Url = "/", SortOrder = 1,  Status = Status.Actived},
            //                new Advertistment(){Name = "Danh mục sản phẩm bên trái 2",Description = "Danh mục sản phẩm bên trái 2", Image = "/", Url = "/", SortOrder = 2,  Status = Status.Actived},
            //                new Advertistment(){Name = "Danh mục sản phẩm bên trái 3",Description = "Danh mục sản phẩm bên trái 3", Image = "/", Url = "/", SortOrder = 3,  Status = Status.Actived}
            //            }
            //            }
            //        }},
            //        new AdvertistmentPage() {Id="product-detail", UniqueCode ="product-detail", Name="Product detail",
            //            AdvertistmentPositions = new List<AdvertistmentPosition>(){
            //            new AdvertistmentPosition(){Id="product-detail-left",Name="Chi tiết sản phẩm bên trái",
            //            Advertistments = new List<Advertistment>()
            //            {
            //                new Advertistment(){Name = "Chi tiết sản phẩm bên trái 1",Description = "Chi tiết sản phẩm bên trái 1", Image = "/", Url = "/", SortOrder = 1,  Status = Status.Actived},
            //                new Advertistment(){Name = "Chi tiết sản phẩm bên trái 2",Description = "Chi tiết sản phẩm bên trái 2", Image = "/", Url = "/", SortOrder = 2,  Status = Status.Actived},
            //                new Advertistment(){Name = "Chi tiết sản phẩm bên trái 3",Description = "Chi tiết sản phẩm bên trái 3", Image = "/", Url = "/", SortOrder = 3,  Status = Status.Actived}
            //            }
            //            }
            //        } },

            //    };
            //    _context.AdvertistmentPages.AddRange(pages);
            //}

            if (!_context.Slides.Any())
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide() { Name="Slide 1",Image="/client-side/images/slider/slide-1.jpg",Url="#",SortOrder = 1,GroupAlias = SlideGroup.Top,Status = Status.Actived  },
                    new Slide() { Name="Slide 2",Image="/client-side/images/slider/slide-2.jpg",Url="#",SortOrder = 2,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Name="Slide 3",Image="/client-side/images/slider/slide-3.jpg",Url="#",SortOrder = 3,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Name="Slide 4",Image="/client-side/images/brand1.png",Url="#",SortOrder = 4,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 5",Image="/client-side/images/brand2.png",Url="#",SortOrder = 5,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 6",Image="/client-side/images/brand3.png",Url="#",SortOrder = 6,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 7",Image="/client-side/images/brand4.png",Url="#",SortOrder = 7,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 8",Image="/client-side/images/brand5.png",Url="#",SortOrder = 8,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 9",Image="/client-side/images/brand6.png",Url="#",SortOrder = 9,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 10",Image="/client-side/images/brand7.png",Url="#",SortOrder = 10,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 11",Image="/client-side/images/brand8.png",Url="#",SortOrder = 11,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 12",Image="/client-side/images/brand9.png",Url="#",SortOrder = 12,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 13",Image="/client-side/images/brand10.png",Url="#",SortOrder = 13,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 14",Image="/client-side/images/brand11.png",Url="#",SortOrder = 14,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 15",Image="/client-side/images/brand11.png",Url="#",SortOrder = 15,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 16",Image="/client-side/images/brand11.png",Url="#",SortOrder = 16,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 17",Image="/client-side/images/brand11.png",Url="#",SortOrder = 17,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 18",Image="/client-side/images/brand11.png",Url="#",SortOrder = 18,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 19",Image="/client-side/images/brand11.png",Url="#",SortOrder = 19,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 20",Image="/client-side/images/brand11.png",Url="#",SortOrder = 20,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 21",Image="/client-side/images/brand11.png",Url="#",SortOrder = 21,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 22",Image="/client-side/images/brand11.png",Url="#",SortOrder = 22,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 23",Image="/client-side/images/brand11.png",Url="#",SortOrder = 23,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 24",Image="/client-side/images/brand11.png",Url="#",SortOrder = 24,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 25",Image="/client-side/images/brand11.png",Url="#",SortOrder = 25,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Name="Slide 26",Image="/client-side/images/brand11.png",Url="#",SortOrder = 26,GroupAlias = SlideGroup.Branch,Status = Status.Actived },

                };
                _context.Slides.AddRange(slides);
            }

            //if (_context.Sizes.Count() == 0)
            //{
            //    List<Size> listSize = new List<Size>()
            //    {
            //        new Size() { Width=100 },
            //        new Size() { Height=200}                    
            //    };
            //    _context.Sizes.AddRange(listSize);
            //}

            if (!_context.ProductCategories.Any())
            {             
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Code="RV01",RelCanonical="Link01",Name="Rem vải",PageAlias="rem-vai",ParentId = null,Status=Status.Actived,SortOrder=1,PageTitle="Rèm vải",MetaDescription="description",
                      Products = new List<Product>()
                        {
                            new Product(){ Name = "Product 1",PageTitle="Product 1",MetaDescription="Description",Tags="rèm vải,rèm vải đẹp",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-1",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 2",PageTitle="Product 2",MetaDescription="Description",Tags="rem vai,rèm vải thô",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-2",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 3",PageTitle="Product 3",MetaDescription="Description",Tags="rèm vải thô",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-3",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 4",PageTitle="Product 4",MetaDescription="Description",Tags="rèm vải",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-4",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 5",PageTitle="Product 5",MetaDescription="Description",Tags="rem vai,thành",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-5",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 6",PageTitle="Product 6",MetaDescription="Description",Tags="rem vai,thành",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-6",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 7",PageTitle="Product 7",MetaDescription="Description",Tags="rem vai,thành",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-7",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        }
                    },
                    new ProductCategory() { Code="RC01",RelCanonical="Link02",Name="Rèm cuốn",PageAlias="rem-cuon",ParentId = null,Status=Status.Actived,SortOrder=2,PageTitle="Rèm cuốn",MetaDescription="description",
                     Products = new List<Product>()
                     {
                            new Product(){ Name = "Product 8",PageTitle="Product 8",MetaDescription="Description",Tags="rem cuon,rèm cuốn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-8",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 9",PageTitle="Product 9",MetaDescription="Description",Tags="rem cuon,rèm cuốn,rèm cuốn rẻ",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-9",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 10",PageTitle="Product 10",MetaDescription="Description",Tags="rem cuốn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-10",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 11",PageTitle="Product 11",MetaDescription="Description",Tags="rem cuon",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-11",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 12",PageTitle="Product 12",MetaDescription="Description",Tags="rem cuon",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-12",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                     }
                    },
                    new ProductCategory() { Code="RG01",RelCanonical="Link03",Name="Rèm gỗ",PageAlias="rem-go",ParentId = null,Status=Status.Actived,SortOrder=3,PageTitle="Rèm gỗ",MetaDescription="description",
                    Products = new List<Product>()
                    {
                            new Product(){ Name = "Product 13",PageTitle="Product 13",MetaDescription="Description",Tags="rem go,rèm gỗ xịn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-13",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 14",PageTitle="Product 14",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-14",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 15",PageTitle="Product 15",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-15",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 16",PageTitle="Product 16",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-16",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 17",PageTitle="Product 17",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-17",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 18",PageTitle="Product 18",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-18",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 19",PageTitle="Product 19",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-19",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 20",PageTitle="Product 20",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-20",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                    }
                    },
                    new ProductCategory() { Code="RLD01",RelCanonical="Link04",Name="Rèm lá dọc",PageAlias="rem-la-doc",ParentId = null,Status=Status.Actived,SortOrder=4,PageTitle="Rèm lá dọc",MetaDescription="description",
                    Products = new List<Product>()
                    {
                            new Product(){ Name = "Product 21",PageTitle="Product 21",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-21",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 22",PageTitle="Product 22",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-22",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 23",PageTitle="Product 23",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-23",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 24",PageTitle="Product 24",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-24",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 25",PageTitle="Product 25",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-25",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){ Name = "Product 26",PageTitle="Product 26",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-26",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                    }
                    },
                    new ProductCategory() { Code="DM05",RelCanonical="Link05",Name="Danh mục 5",PageAlias="danh-muc-5",ParentId = null,Status=Status.Actived,SortOrder=5,PageTitle="Danh mục 5",MetaDescription="Danh mục 5"},
                    new ProductCategory() { Code="DM06",RelCanonical="Link06",Name="Danh mục 6",PageAlias="danh-muc-6",ParentId = null,Status=Status.Actived,SortOrder=6,PageTitle="Danh mục 6",MetaDescription="Danh mục 6"},
                    new ProductCategory() { Code="DM07",RelCanonical="Link07",Name="Danh mục 7",PageAlias="danh-muc-7",ParentId = null,Status=Status.Actived,SortOrder=7,PageTitle="Danh mục 7",MetaDescription="Danh mục 7"},
                    new ProductCategory() { Code="DM08",RelCanonical="Link08",Name="Danh mục 8",PageAlias="danh-muc-8",ParentId = null,Status=Status.Actived,SortOrder=8,PageTitle="Danh mục 8",MetaDescription="Danh mục 8"},
                    new ProductCategory() { Code="DM09",RelCanonical="Link09",Name="Danh mục 9",PageAlias="danh-muc-9",ParentId = null,Status=Status.Actived,SortOrder=9,PageTitle="Danh mục 9",MetaDescription="Danh mục 9"},
                    new ProductCategory() { Code="DM10",RelCanonical="Link10",Name="Danh mục 10",PageAlias="danh-muc-10",ParentId = null,Status=Status.Actived,SortOrder=10,PageTitle="Danh mục 10",MetaDescription="Danh mục 10"},
                    new ProductCategory() { Code="DM11",RelCanonical="Link11",Name="Danh mục 11",PageAlias="danh-muc-11",ParentId = null,Status=Status.Actived,SortOrder=11,PageTitle="Danh mục 11",MetaDescription="Danh mục 11"},
                    new ProductCategory() { Code="DM12",RelCanonical="Link12",Name="Danh mục 12",PageAlias="danh-muc-12",ParentId = null,Status=Status.Actived,SortOrder=12,PageTitle="Danh mục 12",MetaDescription="Danh mục 12"},
                    new ProductCategory() { Code="DM13",RelCanonical="Link13",Name="Danh mục 13",PageAlias="danh-muc-13",ParentId = null,Status=Status.Actived,SortOrder=13,PageTitle="Danh mục 13",MetaDescription="Danh mục 13"},
                    new ProductCategory() { Code="DM14",RelCanonical="Link14",Name="Danh mục 14",PageAlias="danh-muc-14",ParentId = null,Status=Status.Actived,SortOrder=14,PageTitle="Danh mục 14",MetaDescription="Danh mục 14"},
                    new ProductCategory() { Code="DM15",RelCanonical="Link15",Name="Danh mục 15",PageAlias="danh-muc-15",ParentId = null,Status=Status.Actived,SortOrder=15,PageTitle="Danh mục 15",MetaDescription="Danh mục 15"},
                    new ProductCategory() { Code="DM16",RelCanonical="Link16",Name="Danh mục 16",PageAlias="danh-muc-16",ParentId = null,Status=Status.Actived,SortOrder=16,PageTitle="Danh mục 16",MetaDescription="Danh mục 16"},
                    new ProductCategory() { Code="DM17",RelCanonical="Link17",Name="Danh mục 17",PageAlias="danh-muc-17",ParentId = null,Status=Status.Actived,SortOrder=17,PageTitle="Danh mục 17",MetaDescription="Danh mục 17"},
                    new ProductCategory() { Code="DM18",RelCanonical="Link18",Name="Danh mục 18",PageAlias="danh-muc-18",ParentId = null,Status=Status.Actived,SortOrder=18,PageTitle="Danh mục 18",MetaDescription="Danh mục 18"},
                    new ProductCategory() { Code="DM19",RelCanonical="Link19",Name="Danh mục 19",PageAlias="danh-muc-19",ParentId = null,Status=Status.Actived,SortOrder=19,PageTitle="Danh mục 19",MetaDescription="Danh mục 19"},
                    new ProductCategory() { Code="DM20",RelCanonical="Link20",Name="Danh mục 20",PageAlias="danh-muc-20",ParentId = null,Status=Status.Actived,SortOrder=20,PageTitle="Danh mục 20",MetaDescription="Danh mục 20"},
                    new ProductCategory() { Code="DM21",RelCanonical="Link21",Name="Danh mục 21",PageAlias="danh-muc-21",ParentId = null,Status=Status.Actived,SortOrder=21,PageTitle="Danh mục 21",MetaDescription="Danh mục 21"},
                    new ProductCategory() { Code="DM22",RelCanonical="Link22",Name="Danh mục 22",PageAlias="danh-muc-22",ParentId = null,Status=Status.Actived,SortOrder=22,PageTitle="Danh mục 22",MetaDescription="Danh mục 22"},
                    new ProductCategory() { Code="DM23",RelCanonical="Link23",Name="Danh mục 23",PageAlias="danh-muc-23",ParentId = null,Status=Status.Actived,SortOrder=23,PageTitle="Danh mục 23",MetaDescription="Danh mục 23"},
                    new ProductCategory() { Code="DM24",RelCanonical="Link24",Name="Danh mục 24",PageAlias="danh-muc-24",ParentId = null,Status=Status.Actived,SortOrder=24,PageTitle="Danh mục 24",MetaDescription="Danh mục 24"},
                    new ProductCategory() { Code="DM25",RelCanonical="Link25",Name="Danh mục 25",PageAlias="danh-muc-25",ParentId = null,Status=Status.Actived,SortOrder=25,PageTitle="Danh mục 25",MetaDescription="Danh mục 25"},
                };

             
                _context.ProductCategories.AddRange(listProductCategory);               
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new Setting()
                {
                    Id = "HomeTitle",
                    UniqueCode = "HomeTitle",
                    Name = "Tiêu đề trang chủ",
                    TextValue = "Title",                  
                    Status = Status.Actived
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new Setting()
                {
                    Id = "HomeMetaKeyword",
                    UniqueCode = "HomeMetaKeyword",
                    Name = "Từ khoá trang chủ",
                    TextValue = "Keywords",                
                    Status = Status.Actived
                });
            }
            if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new Setting()
                {

                    Id = "HomeMetaDescription",
                    UniqueCode = "HomeMetaDescription",
                    Name = "Mô tả trang chủ",
                    TextValue = "Description",                   
                    Status = Status.Actived
                });
            }

            _context.SaveChanges();
            //await _context.SaveChangesAsync();

        }

    }
}
