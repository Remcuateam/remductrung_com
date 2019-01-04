using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComLengthClassDescriptions")]
    public class LengthClassDescription : DomainEntity<Guid>, IMultiLanguage<Guid>
    {
        public LengthClassDescription()
        {
        }

        public LengthClassDescription(Guid lengthClassId, Guid languageId, string title, string unit)
        {
            LengthClassId = lengthClassId;
            LanguageId = languageId;
            Title = title;
            Unit = unit;
        }

        public Guid LengthClassId { set; get; }
       

        [MaxLength(32)]
        public string Title { set; get; }

        [MaxLength(4)]
        public string Unit { set; get; }

        public Guid LanguageId { get; set; }
    }
}