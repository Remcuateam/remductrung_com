using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductTags")]
    public class ProductTag : DomainEntity<int>
    {
        public ProductTag()
        {
        }

        public ProductTag(int productId, string tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }

        public int ProductId { set; get; }

        public string TagId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}
