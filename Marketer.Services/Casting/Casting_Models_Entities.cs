using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Marketer.DomainClasses.Product;
using Marketer.Utilities.GenericMethods;
using Marketer.ViewModels.Product;

namespace Marketer.Utilities.Casting
{
    public static class Casting_Models_Entities
    {
        #region ProductModel_ProductEntity
            public static List<ProductModel> ToProductModel(this List<Product> products)
            {
            if (products != null)
            {
                return products.Select(s => new ProductModel()
                {
                    Name = s.Name,
                    RegisterDateToShow = s.RegisterDate.ToShamsiDateString(),
                    CategoryID = s.CategoryID,
                    CompanyID = s.CompanyID,
                    UnitID = s.UnitID
                }).ToList();
            }
            else
                return null;
            }

            public static List<Product> ToProductEntity(this IEnumerable<ProductModel> products)
        {
            if (products != null)
            {


                return products.Select(s => new Product()
                {
                    Name = s.Name,
                    RegisterDate = s.RegisterDate,
                    CategoryID = s.CategoryID,
                    CompanyID = s.CompanyID,
                    UnitID = s.UnitID
                }).ToList();
            }
            else
            {
                return null;
            }
        }
        #endregion

        public static T Cast<T>(this Object myobj)
        {
            System.Type objectType = myobj.GetType();
            System.Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;

            foreach (var memberInfo in members)
            {
                try
                {
                    propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                    value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
                    propertyInfo.SetValue(x, value, null);
                }
                catch (Exception)
                {
                }
            }

            return (T)x;
        }

    }
}
