using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Data.Entities.Production
{
    [Table("Materials")]
    public class Material : DomainEntity<Guid>, IDateTracking
    {
        public Material()
        {
            // Material :
            // Chất liệu: Vải Cotton pha Polyester Polyester/Cotton| 100% vải bông Cotton 100% Cotton | 100% vải nhân tạo Polyester  100% Polyester |
            // Hạt nhựa polypropylene 100% Polypropylene | 100% vải tơ lụa 100% Silk| 100% vải lanh 100% Linen | vải lanh bông cotton linen | Pha lê Crystal |
            // Nhựa dẻo Plastic| Gỗ Wood| Kim loại Metal| Nhựa PVC PVC| Vải nhung Velvet Fabric| Vải voan Voile Fabric| Vải lụa ni lông Organza Fabric| 
            // Vải lưới Mesh Fabric| Vải đan (dệt kim) Knitted Fabric| Vải da lộn Suede Fabric| Vải xa tanh Satin Fabric| Vải bóng Taffeta Fabric| 
            // Vải gấm Đa mát Damast Fabric| Vải ren Lace Fabric | 
        }

        //public Material(Guid id, string name, string description)
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
