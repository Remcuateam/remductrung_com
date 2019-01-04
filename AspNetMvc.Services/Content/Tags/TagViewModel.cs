using AspNetMvc.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc.Services.Content.Tags
{
    public class TagViewModel
    {
        public string Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
      
        //[Required]
        public string Type { set; get; }
        //public TagType Type { set; get; }
    }
}