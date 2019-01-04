using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("AttributeGroupDescriptions")]
    public class AttributeGroupDescription : DomainEntity<int>, IMultiLanguage<string>
    {
        public AttributeGroupDescription()
        {
        }

        public AttributeGroupDescription(int attributeGroupId, string languageId, string name)
        {
            AttributeGroupId = attributeGroupId;
            LanguageId = languageId;
            Name = name;
        }

        [Required]
        public int AttributeGroupId { set; get; }

        [Required]
        public string LanguageId { set; get; }

        [Required]
        [MaxLength(64)]
        public string Name { set; get; }

        [ForeignKey("AttributeGroupId")]
        public virtual AttributeGroup AttributeGroup { set; get; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { set; get; }
    }
}