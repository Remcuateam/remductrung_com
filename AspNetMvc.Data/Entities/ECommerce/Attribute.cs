using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Attributes")]
    public class Attribute : DomainEntity<int>, ISortable
    {
        public Attribute()
        {
        }

        public Attribute(int attributeGroupId, string name, int sortOrder)
        {
            AttributeGroupId = attributeGroupId;
            Name = name;
            SortOrder = sortOrder;
        }

        [Required]
        public int AttributeGroupId { set; get; }

        [Required]
        [MaxLength(64)]
        public string Name { set; get; }

        public int SortOrder { get; set; }

        [ForeignKey("AttributeGroupId")]
        public virtual AttributeGroup AttributeGroup { set; get; }
      
    }
}