using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketer.DomainClasses.Product
{
   public class Category
    {
        public Category() { }
        [Key]
        public long CategoryID { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "دسته بندی را حتما وارد کنید")]
        [MaxLength(150)]
        public String Name { get; set; }
        /// <summary>
        /// Navigation Property
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }
}
