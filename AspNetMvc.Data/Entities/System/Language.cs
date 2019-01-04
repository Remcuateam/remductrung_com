using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.System
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable
    {
        public Language()
        {
        }

        public Language(string name, bool isDefault, string resources, Status status)
        {
            Name = name;
            IsDefault = isDefault;
            Resources = resources;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}