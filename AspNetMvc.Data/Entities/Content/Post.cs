using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Posts")]
    public class Post : DomainEntity<int>, ISwitchable, IMetaData, IDateTracking
    {
        public Post()
        {

        }

        public Post(int categoryId, string name, string pageAlias, string description, string image, string content, string tags,
            bool? homeFlag, bool? hotFlag, int? viewCount, Status status, string pageTitle, string metaDescription, string metaKeywords)
        {
            CategoryId = categoryId;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;           
            Content = content;
            Tags = tags;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            ViewCount = viewCount;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;                       
        }

        public Post(int id, int categoryId, string name, string pageAlias, string description, string image, string content, string tags,
            bool? homeFlag, bool? hotFlag, int? viewCount, Status status, string pageTitle, string metaDescription, string metaKeywords)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;
            Content = content;
            Tags = tags;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            ViewCount = viewCount;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
        }
        
      

        [StringLength(255)]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
        public string Content { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
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

        public int CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { set; get; }

        public virtual ICollection<PostTag> PostTags { set; get; }
    }
}