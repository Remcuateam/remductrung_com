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
    [Table("Uses")]
    public class Use : DomainEntity<Guid>
    {
        public Use()
        {
            // Use: Home | Office | Hotel | Hospital | Cafe ...
            // Sử dụng: Nhà | Văn phòng | Khách sạn | Bệnh viện | Quán Cafe | Nhà hàng | Sân khấu | Ô tô | Trường mầm non | Hội trường | Đám cưới | Chung cư | Spa | 
            // nghệ thuật bộ sưu tập | trang trí nội thất
        }

        //public Use(Guid id, string name, string description)
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
    }
}
