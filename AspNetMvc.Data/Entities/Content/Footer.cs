using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Footers")]
    public class Footer : DomainEntity<string>, ISwitchable
    {
        public Footer()
        {
        }

        public Footer(string content, Status status)
        {
            Content = content;
            Status = Status;
        }

        [Required]
        public string Content { set; get; }

        public Status Status { set; get; }
    }
}