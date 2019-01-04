using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetMvc.Data.Enums;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Sizes")]
    public class Size : DomainEntity<int>
    {
        public Size()
        {

        }

        public Size(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }

        [StringLength(255)]
        public string Name { set; get; }

        public int Width { set; get; }
        public int Height { set; get; }

    }
}
