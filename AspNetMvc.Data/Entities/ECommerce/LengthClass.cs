using System;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComLengthClass")]
    public class LengthClass : DomainEntity<Guid>
    {
        public decimal Value { set; get; }
    }
}