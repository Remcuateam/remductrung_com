using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IMetaData, IDateTracking
    {
        public Product()
        {

        }

        public Product(int categoryId, string code, string name, string pageAlias, string description, string image, string content, int? viewCount,
        string tags, string unit, bool? homeFlag, bool? hotFlag, int quantity, decimal price, decimal originalPrice, decimal? promotionPrice, Status status, 
        string pageTitle, string metaDescription, string metaKeywords)
        {
            CategoryId = categoryId;
            Code = code;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;
            Content = content;
            ViewCount = viewCount;
            Tags = tags;
            Unit = unit;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Quantity = quantity;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
        }

        public int CategoryId { set; get; }

        [StringLength(255)]
        public string Code { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        //[Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
        public string Content { get; set; }
        public int? ViewCount { get; set; }

        [StringLength(255)]     
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }     
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        [DefaultValue(0)]
        public int Quantity { set; get; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        public decimal OriginalPrice { get; set; }
        public Status Status { set; get; }

        [StringLength(70)]
        [Required]
        public string PageTitle { set; get; }

        [StringLength(300)]
        [Required]
        public string MetaDescription { set; get; }
        public string MetaKeywords { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        //[ForeignKey("StyleId")]
        //public virtual Style Style { set; get; }

        //[ForeignKey("PatternId")]
        //public virtual Pattern Pattern { set; get; }

        //[ForeignKey("MaterialId")]
        //public virtual Material Material { set; get; }
    }
}