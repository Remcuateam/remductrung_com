﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetMvc.Services.System.Users.Dtos;

namespace AspNetMvc.Services.ECommerce.Products.Dtos
{
    public class ProductWishlistViewModel
    {      
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }     

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        //public DateTime? DeletedDate { set; get; }

        public AppUserViewModel AppUser { get; set; }

        public ProductViewModel Product { set; get; }
    }
}
