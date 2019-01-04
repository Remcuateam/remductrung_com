using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Data.Entities.System;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductWishlists")]
    public class ProductWishlist : DomainEntity<int>, IDateTracking
    {
        public ProductWishlist()
        {
        }

        public ProductWishlist(int id, Guid userId, int productId)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
        }

        public int ProductId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
    }
}