using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc.Services.ECommerce.Products.Dtos
{
    public class SizeViewModel
    {
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Name { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
    }
}