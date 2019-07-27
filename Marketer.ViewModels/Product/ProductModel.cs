using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketer.ViewModels.Product
{
   public class ProductModel
    {
        public long ProductID { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا نام محصول را وارد کنید")]
        [MaxLength()]
        //[DataType(DataType.MultilineText)]
        public string Name { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public string RegisterDateToShow { get; set; }
        [Required]
        public long CategoryID { get; set; }
        [Required]
        public long UnitID { get; set; }
        [Required]
        public long CompanyID { get; set; }
    }
}
