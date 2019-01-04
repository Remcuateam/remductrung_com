using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("ProductCategoryDescriptions")]
    public class ProductCategoryDescription : DomainEntity<Guid>, IMetaData /*,IMultiLanguage<Guid>*/
    {
        public ProductCategoryDescription()
        {
        }

        public ProductCategoryDescription(Guid productCategoryId, 
            //Guid languageId, 
            string name, string description, string pageTitle, string pageAlias, string metaKeywords, string metaDescription)
        {
            ProductCategoryId = productCategoryId;
            //LanguageId = languageId;
            Name = name;
            Description = description;
            PageTitle = pageTitle;
            PageAlias = pageAlias;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        [Required]
        public Guid ProductCategoryId { set; get; }

        //[Required]
        //public Guid LanguageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { set; get; }

        public string Description { set; get; }

        [MaxLength(255)]
        [Required]
        public string PageAlias { get; set; }

        [MaxLength(70)]
        [Required]
        public string PageTitle { get; set; }
            
        [MaxLength(300)]
        [Required]
        public string MetaDescription { get; set; }

        [MaxLength(255)]
        public string MetaKeywords { get; set; }      
    }
}