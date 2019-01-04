using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Advertistment
{
    [Table("Advertistments")]
    public class Advertistment : DomainEntity<int>, ISortable, ISwitchable, IDateTracking
    {
        public Advertistment()
        {
        }

        public Advertistment(string positionId, string name, string description, string image, string url, int sortOrder, Status status)
        {           
            Name = name;
            Description = description;
            Image = image;
            Url = url;
            SortOrder = sortOrder;
            Status = status;
            PositionId = positionId;
        }
     
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        [Required]
        public string Url { get; set; }

        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }

        [StringLength(20)]
        public string PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
    }
}