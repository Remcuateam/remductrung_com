using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Styles")]
    public class Style : DomainEntity<Guid>, IDateTracking
    {
        public Style()
        {
            // Style: Roman | Traditional Truyền thống| Modern & Contemporary Hiện đại| Glam Quyến rũ| Cottage/Country Đồng quê| Rustic Giản dị mộc mạc| 
            // Coastal Ven biển| Industrial Công nghiệp| Cabin/Lodge Cabin và nhà nhỏ| Jacquard Dệt hoa| Stripe Sọc| Folk Art Dân gian| Plain Trơn |
            // Euro&American Âu Mỹ | American Mỹ | Bohemian phóng túng | Nhật | Trung Hoa truyền thống | Pastoral đồng quê| New classical/Post-modem tân cổ điển - hậu hiện đại|
            // Nhật Hàn | Đông Nam Á | Mediterranean địa trung hải | Europe Âu | Hàn Quốc
             
        }

        //public Style(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }


        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
        //public virtual ICollection<Product> Products { set; get; }
    }
}
