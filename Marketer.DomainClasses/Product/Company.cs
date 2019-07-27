using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketer.DomainClasses.Product
{
   public class Company
    {
        [Key]
        public long CompanyID { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "نام شرکت را حتما وارد کنید")]
        [Display(Name="نام شرکت")]
        public string Name { get; set; }
        [MaxLength(500)]
        [Display(Name="آدرس شرکت")]
        public string Address { get; set; }
        [MaxLength(11)]
        [Display(Name = "تلفن شرکت")]
        public string Mobile { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
