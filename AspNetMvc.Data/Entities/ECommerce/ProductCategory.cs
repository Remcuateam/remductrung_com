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

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>,ISortable, ISwitchable, IMetaData, IDateTracking
    {
        public ProductCategory()
        {
        }

        //public ProductCategory()
        //{
        //    Products = new List<Product>();
        //}

        public ProductCategory(int? parentId, string code, string name, string pageAlias, string description, string image, bool? homeFlag, 
            int? homeOrder, int sortOrder, Status status, string relCanonical, string pageTitle, string metaKeywords, string metaDescription)
        {
            ParentId = parentId;
            RelCanonical = relCanonical;
            Code = code;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;                            
            HomeFlag = homeFlag;
            HomeOrder = homeOrder;
            SortOrder = sortOrder;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;            
        }
              
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

        public virtual ICollection<Product> Products { set; get; }
    }
}
