﻿using AspNetMvc.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc.Data.Entities.ECommerce
{
    [Table("Locations")]
    public class Location : DomainEntity<Guid>
    {
        public Location()
        {
            // Location: Living Room | Bathroom | Bedroom | Dining Room | Window | Door | Kitchen | Children's | Stairs
            // Vị trí: Phòng khách | Phòng tắm | Phòng ngủ | Phòng ăn | Phòng trẻ em | Phòng bếp | Phòng họp | Phòng thay đồ | phòng thờ |
            // Cửa sổ | Cửa chính | Cửa chớp | Cầu thang | Nhà vệ sinh | Ban công | Điều hòa | Ngăn kho lạnh | Gác lửng | Mái hiên | Gác xép | Giếng trời |
        }

        //public Location(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
