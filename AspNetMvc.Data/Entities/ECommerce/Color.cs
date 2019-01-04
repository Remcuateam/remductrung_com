using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Colors")]
    public class Color : DomainEntity<int>
    {
        public Color()
        {

        }

        public Color(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
        public string Code { get; set; }
    }
}
