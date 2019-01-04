using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductAttributes")]
    public class ProductAttribute : DomainEntity<int>, IMultiLanguage<string>
    {
        [Required]
        public int ProductId { set; get; }

        [Required]
        public int AttributeId { set; get; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        public string Text { set; get; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { set; get; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
    }
}