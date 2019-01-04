using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Services.Content.PostCategories.Dtos;

namespace AspNetMvc.Services.Content.Posts.Dtos
{
    public class PostViewModel
    {
        
        public int Id { get; set; }

        
        public int CategoryId { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
      
        public string Content { set; get; }

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

        public PostCategoryViewModel PostCategory { set; get; }
        public ICollection<PostTagViewModel> PostTags { set; get; }
    }
}