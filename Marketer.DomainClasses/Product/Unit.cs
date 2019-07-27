using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketer.DomainClasses.Product
{
   public class Unit
    {
        [Key]
        public long UnitID { get; set; }
        [Display(Name ="نام واحد")]
        [Required(ErrorMessage ="نام دسته بندی را حتما وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
