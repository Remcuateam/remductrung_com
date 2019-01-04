using System;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.Content.Footers.Dtos
{
    public class FooterViewModel
    {
        public string Id { set; get; }

        [Required]
        public string Content { set; get; }

        public Status Status { set; get; }
    }
}