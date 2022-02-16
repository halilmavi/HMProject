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
            // ProductTest();
            // CategoryTest();
            // ProductDetailsTest();

            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in productManager.GetAll().Data)
                {
                    Console.WriteLine(product.ProductName);
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           


        }

        private static void ProductDetailsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            // İş sınıfımız olan CategoryManager da bulunan metotları kullanmak icin tanımladık burada.
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            // İş sınıfımız olan ProductManager da bulunan metotları kullanmak icin tanımladık burada.
            // IProductDal tipinde bizden parametre istiyor. Interface'ler new'lenemedigi icin interfacemizin referansini tuttugu EfProductDal() sinifini parametre olarak gonderme islemi yapabiliriz.
            // ProductManager'a parametre olarak gondermis oldugumuz new EfProductDal() sinifi Category sinifi turunde nesneyi bize dondurecek.
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
