using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComCouponCategorys")]
    public class CouponCategory : DomainEntity<Guid>
    {
        public CouponCategory()
        {
        }

        public CouponCategory(Guid couponId, Guid productCategoryId)
        {
            CouponId = couponId;
            ProductCategoryId = productCategoryId;
        }

        [Required]
        public Guid CouponId { set; get; }

        [Required]
        public Guid ProductCategoryId { set; get; }
    }
}