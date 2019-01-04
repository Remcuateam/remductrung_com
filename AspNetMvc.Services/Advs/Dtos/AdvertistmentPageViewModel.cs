using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.Advs.Dtos
{
    public class AdvertistmentPageViewModel
    {
        public string Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string UniqueCode { get; set; }
        
        public List<AdvertistmentPositionViewModel> AdvertistmentPositions { set; get; }
    }
}