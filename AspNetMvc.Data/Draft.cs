using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Data.Entities
{
    /// AppUser inherit from IdentityUser, AppRole inherit from IdentityRole:
    /// using Microsoft.AspNetCore.Identity;  
    /// (NuGet Packages)
    /// Microsoft.AspNetCore.Identity.EntityFrameworkCore (2.0.0)


    /// Commands for Migration in Package Manager Console (Add-Migration, Update-Database):
    /// (NuGet Packages)
    /// Microsoft.EntityFrameworkCore (2.0.0)
    /// Microsoft.EntityFrameworkCore.SqlServer (2.0.0)
    /// Microsoft.EntityFrameworkCore.Tools (2.0.0)
    /// Microsoft.Extensions.Configuration (2.0.0)


    /// Data Annotation:
    /// [DefaultValue(0)]
    /// using System.ComponentModel;
    /// 
    /// [StringLength(255)]
    /// [MaxLength(255, ErrorMessage = "Số điện thoại không vượt quá 50 ký tự")]
    /// [EmailAddress]
    /// [Required(ErrorMessage = "Tên phải nhập")]
    /// using System.ComponentModel.DataAnnotations;
    /// 
    /// [ForeignKey("")]
    /// [Table("Posts")]
    /// [Column(TypeName = "varchar")]
    /// [Column(Order = 1)]
    /// using System.ComponentModel.DataAnnotations.Schema;


    ///  public virtual ICollection<Post> Posts { set; get; }
    ///  using System.Collections.Generic;

    //public class Draft
    //{       
    //    public string Name { set; get; }
    //        [DefaultValue(Status.Actived)]
    //        public Status Status { set; get; } = Status.Actived;
    //        [DefaultValue(0)]
    //        [StringLength(255)]
    //        [MaxLength(255, ErrorMessage = "Số điện thoại không vượt quá 50 ký tự")]
    //        [Required]
    //        [EmailAddress]
    //        [Required(ErrorMessage = "Tên phải nhập")]
    //        [Column(TypeName="varchar")]
    //        [Column(Order = 1)]
    //        public string Name { set; get; }
    //        public Guid CategoryId { set; get; }
    //        [ForeignKey("CategoryId")]
    //        public virtual ProductCategory ProductCategory { set; get; }
    //        public virtual ICollection<Product> Products { set; get; }
    //}

    // Use: Home | Office | Hotel | Hospital | Cafe ...
    // Sử dụng: Nhà | Văn phòng | Khách sạn | Bệnh viện | Quán Cafe | Nhà hàng | Sân khấu | Ô tô | Mầm non | Hội trường | Đám cưới | Chung cư | Spa | Y tế...

    // Location: Living Room | Bathroom | Bedroom | Dining Room | Window | Door | Kitchen | Children's | Stairs
    // Vị trí: Phòng khách | Phòng tắm | Phòng ngủ | Phòng ăn | Phòng trẻ em | Phòng bếp | Phòng họp | Phòng thay đồ | phòng thờ |
    // Cửa sổ | Cửa chính | Cửa chớp | Cầu thang | Nhà vệ sinh | Ban công | Điều hòa | Ngăn kho lạnh | Gác lửng | Mái hiên | Gác xép | Giếng trời |

    // Material : Polyester/Cotton | 100% Cotton | 100% Polyester | 100% Polypropylene | 100% Silk | 100% Linen | Crystal | Plastic | 
    // Wood | Metal | PVC | Velvet Fabric | Voile Fabric | Organza Fabric | Mesh Fabric | Knitted Fabric | Suede Fabric | Satin Fabric | 
    // Taffeta Fabric | Damast Fabric | Lace Fabric | 
    // Chất liệu: Vải Cotton pha Polyester | 100% vải bông Cotton | 100% vải nhân tạo Polyester | Hạt nhựa polypropylene | 
    // 100% vải tơ lụa | 100% vải lanh | Pha lê | Nhựa dẻo | Gỗ | Kim loại | Nhựa PVC | Vải nhung | Vải voan | Vải lụa ni lông | 
    // Vải lưới | Vải đan (dệt kim) | Vải da lộn | Vải xa tanh | Vải bóng | Vải gấm Đa mát | Vải ren 

    // Feature: Blackout | Flame Retardant | Insulated | Decoration | Eco-Friendly | Anti-Static | Anti-Pilling | 
    // Tính năng, công năng: cản sáng | không cháy | cách điện | trang trí | thân thiện môi trường | chống tĩnh điện | chống nhăn

    // Style: Roman | Traditional | Modern & Contemporary | Glam | Cottage/Country | Rustic | Coastal | Industrial | Cabin/Lodge | Jacquard | Stripe | Folk Art | Plain 
    // Phong cách: Roman | Truyền thống | Hiện đại | Quyến rũ | Đồng quê | Giản dị mộc mạc | Ven biển | Công nghiệp | Cabin và nhà nhỏ | Dệt hoa | Sọc | Dân gian | Trơn 

    // Technic: Woven | Knitted | Nonwoven | 
    // Kỹ thuật: Dệt (dệt thoi) | Đan (dệt kim) | Không dệt (vải không dệt) 

    // Pattern: Printed | Pleated | Embroidered | Flocked | Yarn Dyed | Beaded | Burnout | Dyed | Vertical
    // Hoa văn họa tiết: In | Xếp ly | Thêu | Bông len | Sợi nhuộm | Đính hạt | ... | Nhuộm | ...
}
