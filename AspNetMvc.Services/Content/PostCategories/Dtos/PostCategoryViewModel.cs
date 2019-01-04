using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Services.Content.Posts.Dtos;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.Content.PostCategories.Dtos
{
    public class PostCategoryViewModel
    {
        public int Id { get; set; }
        public int? ParentId { set; get; }

        [DefaultValue(0)]
        public int CurrentIdentity { get; set; }

        [StringLength(255)]
        [Required]
        public string CategoryName { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }
        public string Description { set; get; }

        [StringLength(255)]
        public string CategoryImage { set; get; }
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
        public List<PostViewModel> Posts { set; get; }
    }
}