using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductQuantities")]
    public class ProductQuantity : DomainEntity<int>
    {
        public ProductQuantity()
        {

        }
        public ProductQuantity(int sizeId, int colorId, int productId)
        {
            SizeId = sizeId;
            ColorId = colorId;
            ProductId = productId;
        }

        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Column(Order = 2)]
        public int SizeId { get; set; }

        [Column(Order = 3)]
        public int ColorId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
