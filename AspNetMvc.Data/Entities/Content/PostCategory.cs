using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("PostCategories")]
    public class PostCategory : DomainEntity<int>, ISortable, ISwitchable, IMetaData, IDateTracking
    {
        public PostCategory()
        {
        }

        //public PostCategory()
        //{
        //    Posts = new List<Post>();
        //}

        public PostCategory(int id, int? parentId, int currentIdentity, string name, string pageAlias, string description, string image, bool? homeFlag,
            int? homeOrder, int sortOrder, Status status, string relCanonical, string pageTitle, string metaKeywords, string metaDescription)
        {
            Id = id;
            ParentId = parentId;
            CurrentIdentity = currentIdentity;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;
            HomeFlag = homeFlag;
            HomeOrder = homeOrder;
            SortOrder = sortOrder;
            Status = status;
            RelCanonical = relCanonical;
            PageTitle = pageTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        public PostCategory(int? parentId, int currentIdentity, string name, string pageAlias, string description, string image, bool? homeFlag, int? homeOrder, int sortOrder, Status status, string relCanonical, string pageTitle, string metaDescription, string metaKeywords)
        {
            ParentId = parentId;
            CurrentIdentity = currentIdentity;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;
            HomeFlag = homeFlag;
            HomeOrder = homeOrder;
            SortOrder = sortOrder;
            Status = status;
            RelCanonical = relCanonical;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
         
        }

        public int? ParentId { set; get; }

        [DefaultValue(0)]
        public int CurrentIdentity { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }

        public bool? HomeFlag { set; get; }
        public int? HomeOrder { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

        [StringLength(255)]
        [Required]
        public string RelCanonical { set; get; }

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

        public virtual ICollection<Post> Posts { set; get; }
    }
}