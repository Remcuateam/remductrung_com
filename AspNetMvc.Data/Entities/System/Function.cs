using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.System
{
    [Table("Functions")]
    public class Function : DomainEntity<string>, ISortable
    {
        public Function()
        {
        }

        public Function(string name, string url, string parentId, string cssClass, int sortOrder, Status status)
        {
           
            Name = name;
            Url = url;
            ParentId = parentId;
            CssClass = cssClass;
            SortOrder = sortOrder;
            Status = status;
        }      

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        public string Url { set; get; }

        [StringLength(128)]
        public string ParentId { set; get; }

        [StringLength(255)]
        public string CssClass { set; get; }

        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}