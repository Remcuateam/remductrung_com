using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("AttributeGroups")]
    public class AttributeGroup : DomainEntity<int>, ISortable
    {
        public AttributeGroup()
        {
        }
        public AttributeGroup(string name, int sortOrder)
        {
            Name = name;
            SortOrder = sortOrder;
        }

        [Required]
        [MaxLength(64)]
        public string Name { set; get; }

        public int SortOrder { get; set; }

        public virtual ICollection<Attribute> Attributes { set; get; }
    }
}