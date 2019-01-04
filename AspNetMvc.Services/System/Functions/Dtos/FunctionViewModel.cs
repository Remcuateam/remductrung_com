using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetMvc.Infrastructure.Enums;

namespace AspNetMvc.Services.System.Functions.Dtos
{
    public class FunctionViewModel
    {
        public string Id { set; get; }      

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }

        public string ParentId { set; get; }
        //public string ParentList { set; get; }
        public string CssClass { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}
