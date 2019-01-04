using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.System.Settings.Dtos
{
    public class SystemConfigViewModel
    {        

        public Guid Id { set; get; }
      
        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [StringLength(128)]
        [Required]
        public string UniqueCode { get; set; }

        public string TextValue { get; set; }

        public int? IntegerValue { get; set; }

        public bool? BooleanValue { get; set; }

        public DateTime? DateValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string Description { set; get; }
      
        public Status Status { get; set; }
    }
}
