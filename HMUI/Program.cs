using HMBusiness.Concrete;
using HMDataAccess.Abstract;
using HMDataAccess.Concrete.EntityFramework;
using HMDataAccess.Concrete.InMemory;
using HMEntities.Concrete;
using System;

namespace HMUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IProductDal tipinde bizden parametre istiyor. Interface'ler new'lenemedigi icin interfacemizin referansini tuttugu EfProductDal() sinifini parametre olarak gonderme islemi yapabiliriz.
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }


         

         
            
            
        }
    }
}
