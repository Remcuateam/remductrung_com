using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Services.ECommerce.Products.Dtos;
using AspNetMvc.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetMvc.Services.ECommerce.ProductCategories.Dtos
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        public string Code { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        public int? ParentId { set; get; }

        [StringLength(70)]
        [Required]
        public string PageTitle { set; get; }

        [StringLength(300)]
        [Required]
        public string MetaDescription { set; get; }

        public string MetaKeywords { set; get; }


        [StringLength(255)]
        //[Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        [Required]
        public string RelCanonical { set; get; }

        [StringLength(255)]
        public string Image { set; get; }

        public string Description { set; get; }

        public bool? HomeFlag { set; get; }
        public int? HomeOrder { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        [DefaultValue(0)]
        public int CurrentIdentity { get; set; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }


        public List<ProductCategoryViewModel> Products { set; get; }
    }
}