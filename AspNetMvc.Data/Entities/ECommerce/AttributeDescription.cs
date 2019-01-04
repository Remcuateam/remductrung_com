using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("AttributeDescriptions")]
    public class AttributeDescription : DomainEntity<int>, IMultiLanguage<string>
    {
        public AttributeDescription()
        {
        }

        public AttributeDescription(int attributeId, string languageId, string name)
        {
            AttributeId = attributeId;
            LanguageId = languageId;
            Name = name;
        }

        [Required]
        public int AttributeId { set; get; }

        [Required]
        public string LanguageId { set; get; }

        [Required]
        [MaxLength(64)]
        public string Name { set; get; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { set; get; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { set; get; }
    }
}