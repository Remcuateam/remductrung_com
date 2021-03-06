﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("EComOptionValues")]
    public class OptionValue : DomainEntity<Guid>, ISortable
    {
        public OptionValue()
        {
        }

        public OptionValue(Guid optionId, string image, int sortOrder)
        {
            OptionId = optionId;
            Image = image;
            SortOrder = sortOrder;
        }

        [Required]
        public Guid OptionId { set; get; }

        [MaxLength(128)]
        public string Image { set; get; }

        public int SortOrder { get; set; }
    }
}