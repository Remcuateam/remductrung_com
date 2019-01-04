using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Pages")]
    public class Page : DomainEntity<int>, ISwitchable, IMetaData, IDateTracking
    {
        public Page()
        {
        }

        public Page(string name, string pageAlias, string image, string content, Status status, string pageTitle, string metaDescription, string metaKeywords)
        {
            Name = name;
            PageAlias = pageAlias;
            Image = image;
            Content = content;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;          
        }

        public Page(int id, string name, string pageAlias, string image, string content, Status status,
           string pageTitle, string metaDescription, string metaKeywords)
        {
            Id = id;
            Name = name;
            PageAlias = pageAlias;
            Image = image;
            Content = content;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Image { set; get; }

        public string Content { get; set; }
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
    }
}