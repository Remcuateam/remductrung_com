using System;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComProductOptions")]
    public class ProductOption : DomainEntity<Guid>
    {
        public Guid ProductId { set; get; }
        public Guid OptionId { set; get; }
        public string Value { set; get; }
        public bool Required { set; get; }
    }
}