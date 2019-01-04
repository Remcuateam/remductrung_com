using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductCategoryFilters")]
    public class ProductCategoryFilter : DomainEntity<Guid>
    {
        public ProductCategoryFilter()
        {
        }

        public ProductCategoryFilter(Guid productCategoryId, Guid filterId)
        {
            ProductCategoryId = productCategoryId;
            FilterId = filterId;
        }

        [Required]
        public Guid ProductCategoryId { set; get; }

        [Required]
        public Guid FilterId { set; get; }
    }
}