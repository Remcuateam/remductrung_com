using System;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComCustomFieldDescriptions")]
    public class CustomFieldDescription : DomainEntity<Guid>, IMultiLanguage<Guid>
    {
        public Guid CustomFieldId { set; get; }
        public Guid LanguageId { get; set; }
        public string Name { set; get; }
    }
}