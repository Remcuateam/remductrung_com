using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductImages")]
    public class ProductImage : DomainEntity<int>, ISortable
    {
        public ProductImage()
        {

        }

        public ProductImage(int id, int productId, string path, string caption)
        {
            Id = id;
            ProductId = productId;
            Path = path;
            Caption = caption;
        }

        public int ProductId { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        [StringLength(255)]
        public string Caption { get; set; }

        public int SortOrder { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
