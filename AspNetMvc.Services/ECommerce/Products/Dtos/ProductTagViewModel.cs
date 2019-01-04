using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Services.Content.Tags;
using AspNetMvc.Services.ECommerce.ProductCategories.Dtos;

namespace AspNetMvc.Services.ECommerce.Products.Dtos
{
    public class ProductTagViewModel
    {
        //public Guid Id { set; get; }
        public Guid ProductId { set; get; }

        public string TagId { set; get; }

        //public virtual ProductViewModel Post { set; get; }

        //public virtual TagViewModel Tag { set; get; }
    }
}