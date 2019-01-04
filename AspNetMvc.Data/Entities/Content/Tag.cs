using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Tags")]
    public class Tag : DomainEntity<string>
    {
        public Tag()
        {
        }

        public Tag(string name, string type)
        {
            Name = name;
            Type = type;
        }
       
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        //[Required]
        public string Type { get; set; }
        //public TagType Type { get; set; }
    }
}