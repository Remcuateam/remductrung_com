using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Advertistment
{
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<string>, IUniqueCode
    {
        public AdvertistmentPage()
        {
        }

        public AdvertistmentPage(string uniqueCode, string name)
        {
            UniqueCode = uniqueCode;
            Name = name;
        }

        [StringLength(255)]
        [Required]
        public string UniqueCode { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}