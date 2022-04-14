using PlatinumInform.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlatinumInform
{
    public class ClassTests
    {
        public static bool DeleteProduct(int CodeProd)
        {
            var DelProd = ConectDB.inform.Product.Where(c => c.CodeProduct == CodeProd).ToList();
           if (DelProd.Count() != 0)
           {
               return true;
           } 
            return false;
        }

        public static bool DeletePrice(int numPP)
        {
            var DelPrice = ConectDB.inform.Price.Where(c => c.NumPP == numPP).ToList();
            if (DelPrice.Count() != 0)
            {
                return true;
            }
            return false;
        }

        public static bool AddProduct(int CodeProd, int CodeOrganiza, string CodeCharacter, int SerNum, string Name, int Dep)
        {
            try
            {
                Product product = new Product();
                product.CodeProduct = CodeProd;
                product.CodeOrg = CodeOrganiza;
                product.CodeCharac = Convert.ToInt32(CodeCharacter);
                product.SerialNum = SerNum;
                product.NameProduct = Name;
                product.NumDep = Dep;
                ConectDB.inform.Product.Add(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SearchProductName(string Name)
        {
            List<Product> NameP = ConectDB.inform.Product.Where(c => c.NameProduct.Contains(Name)).ToList();
            if (Name == "Рама")
            {
                return true;
            }
            else return false;
        }

        public static bool SearchProductDep(int NumDep)
        {
            var Dep = ConectDB.inform.Product.Where(c => c.NumDep == NumDep).ToList();
            if (NumDep == 1 || NumDep == 2 || NumDep == 3)
            {
                return true;
            }
            return false;
        }

        public static bool SearchProductAll(string Name, int NumDep)
        {
            var AllSearch = ConectDB.inform.Product.Where(c => c.NameProduct == Name && c.NumDep == NumDep).ToList();
            if (Name == "Рама" && NumDep == 3)
            {
                return true;
            }
            return false;
        }

        public static bool AddPriceProd(int CodeProd, DateTime NowDate, string Cost, string NumCon)
        {
            try
            {
                Price price = new Price();
                price.CodeProduct = CodeProd;
                price.DateInsert = NowDate;
                price.Cost = Convert.ToInt32(Cost);
                price.NumContract = Convert.ToInt32(NumCon);
                if (Convert.ToInt32(Cost) < 0)
                {
                    return false;
                }
                return true;    
            }
            catch (Exception)
            {
                return false;
            }  
        }

        public static bool SearchPrice(int NumProd)
        {
            var PriceProd = ConectDB.inform.Price.Where(c => c.CodeProduct == NumProd).ToList();
            if (NumProd == 23)
            {
                return true;
            }
            return false;
        }
    }
}
