using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>, ISortable
    {
        public Slide()
        {
        }

        public Slide(int id, string name, string image, string url, int sortOrder, Status status, SlideGroup groupAlias)
        {
            Id = id;
            Name = name;
            Image = image;
            Url = url;
            SortOrder = sortOrder;
            Status = status;
            GroupAlias = groupAlias;
        }

        public Slide(string name, string description, string image, string content, string url, int sortOrder, Status status, SlideGroup groupAlias)
        {
            Name = name;
            Description = description;
            Image = image;
            Content = content;
            Url = url;
            SortOrder = sortOrder;
            Status = status;
            GroupAlias = groupAlias;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Image { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }

        public int SortOrder { set; get; }

        [Required]
        public SlideGroup GroupAlias { get; set; }

        public Status Status { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

        public string Content { set; get; }
        
    }
}