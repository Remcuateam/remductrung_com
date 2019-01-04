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
    [Table("Patterns")]
    public class Pattern : DomainEntity<Guid>, IDateTracking
    {
        public Pattern()
        {
            // Pattern-Hoa văn họa tiết      
            // Printed In | Pleated Xếp ly | Embroidered thêu | Flocked | Yarn Dyed nhuộm sợi|  plain dyed nhuộm trơn | floral in hoa | flocked đổ xô
            // horizontal ngang | beaded đính hạt cườm | burnout | dyed nhuộm | bông len | Vertical dọc
            
        }

        //public Pattern(Guid id, string name, string description)
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
