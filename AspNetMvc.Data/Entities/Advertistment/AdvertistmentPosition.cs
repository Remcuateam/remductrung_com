using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Advertistment
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntity<string>
    {
        public AdvertistmentPosition()
        {
        }

        public AdvertistmentPosition(string pageId, string name)
        {
            PageId = pageId;
            Name = name;
        }
       
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        public string PageId { set; get; }

        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }
        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}