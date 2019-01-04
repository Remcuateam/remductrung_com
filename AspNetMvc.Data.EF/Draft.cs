using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvc.Data.EF
{
    

    /// Data Annotation:
    /// [DefaultValue(0)]
    /// using System.ComponentModel;
    /// 
    /// [StringLength(255)]
    /// [MaxLength(255, ErrorMessage = "Số điện thoại không vượt quá 50 ký tự")]
    /// [EmailAddress]
    /// [Required(ErrorMessage = "Tên phải nhập")]
    /// using System.ComponentModel.DataAnnotations;
    /// 
    /// [ForeignKey("")]
    /// [Table("Posts")]
    /// [Column(TypeName = "varchar")]
    /// [Column(Order = 1)]
    /// using System.ComponentModel.DataAnnotations.Schema;


    ///  public virtual ICollection<Post> Posts { set; get; }
    ///  using System.Collections.Generic;

    //public class Draft
    //{       
    //    public string Name { set; get; }
    //        [DefaultValue(Status.Actived)]
    //        public Status Status { set; get; } = Status.Actived;
    //        [DefaultValue(0)]
    //        [StringLength(255)]
    //        [MaxLength(255, ErrorMessage = "Số điện thoại không vượt quá 50 ký tự")]
    //        [Required]
    //        [EmailAddress]
    //        [Required(ErrorMessage = "Tên phải nhập")]
    //        [Column(TypeName="varchar")]
    //        [Column(Order = 1)]
    //        public string Name { set; get; }
    //        public Guid CategoryId { set; get; }
    //        [ForeignKey("CategoryId")]
    //        public virtual ProductCategory ProductCategory { set; get; }
    //        public virtual ICollection<Product> Products { set; get; }
    //}
}
