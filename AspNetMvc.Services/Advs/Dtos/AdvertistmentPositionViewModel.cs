using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.Advs.Dtos
{
    public class AdvertistmentPositionViewModel
    {
        public string Id { set; get; }
        public string PageId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public AdvertistmentPageViewModel AdvertistmentPage { set; get; }

        public List<AdvertistmentViewModel> Advertistments { set; get; }

    }
}