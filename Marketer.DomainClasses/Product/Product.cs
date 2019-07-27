using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketer.DomainClasses.Product
{
   public class Product
    {
       public Product()
        {
        }

        [Key]
        public long ProductID { get; set; }
        [Display(Name ="نام محصول")]
        [Required(ErrorMessage ="لطفا نام محصول را وارد کنید")]
        [MaxLength()]
        public string Name { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime  RegisterDate { get; set; }
        [Required]
        public long CategoryID { get; set; }
        [Required]
        public long UnitID { get; set; }
        [Required]
        public long  CompanyID{ get; set; }

        /// <summary>
        /// Navigation Property
        /// </summary>
        public virtual Category Category { get; set; }
        public virtual Unit Unit{ get; set; }
        public virtual Company Company { get; set; }
    }
}
