using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.System
{
    [Table("Settings")]
    public class Setting : DomainEntity<string>, ISwitchable, IUniqueCode
    {
        public Setting()
        {
        }

        public Setting(string uniqueCode, string name, string textValue, Status status)
        {
            UniqueCode = uniqueCode;
            Name = name;
            TextValue = textValue;
            Status = status;
        }

        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [StringLength(128)]
        [Required]
        public string UniqueCode { get; set; }

        public string TextValue { get; set; }

        public int? IntegerValue { get; set; }

        public bool? BooleanValue { get; set; }

        public DateTime? DateValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string Description { set; get; }

        public Status Status { get; set; }
    }
}