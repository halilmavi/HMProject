using HMDataAccess.Abstract;
using HMEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HMDataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // Class icerisinde metotların dışında tanımlamis oldugumuz degişkenlere global değişken deriz. Alt cizgi ile baslayarak isimlendirme standartına göre tanimlama islemi yapariz.
        List<Product> _products;

        public InMemoryProductDal()
        {
            // Oracle, Sql Server, Postgres, MongoDb veritabanlarından geliyormuş gibi simule etme işlemi yaptik.
            _products = new List<Product>
            {
               new Product{ProductId=1,ProductName="Laptop", UnitPrice=1500, UnitsInStock=15, CategoryId=3 },
               new Product{ProductId=2,ProductName="Kamera", UnitPrice=1500, UnitsInStock=15, CategoryId=3 },
               new Product{ProductId=3,ProductName="Buzdolabı", UnitPrice=1500, UnitsInStock=15, CategoryId=2 },
               new Product{ProductId=4,ProductName="Çamaşır Makinası", UnitPrice=1500, UnitsInStock=15, CategoryId=2 },
               new Product{ProductId=5,ProductName="Saç Kurutması", UnitPrice=1500, UnitsInStock=15, CategoryId=2 },
               new Product{ProductId=6,ProductName="Fare", UnitPrice=1500, UnitsInStock=15, CategoryId=3 },
            }; 
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {   
            Product productToDelete=null;

            // p.ProductId = Veritabanimizdaki urunun Id'si 
            // product.ProductId = Arayuzden Business katmanına gondermis oldugumuz ProductId 
            // Asagida yazmis oldugumuz linq sorgusu ile veritabanındaki ProductId ile arayuzden gelen ProductId'i karsilastirip esitse onun referansini productToDelete degiskenine atayacak.
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);                  
        }

        //GetAll metodumuz ürünleri listeleycek bir metot olduğu için verileri List ile tutmasini tanimladik. 
        public List<Product> GetAll()
        {
            return _products;
        }      

        public void Update(Product product)
        {
            Product productToUpdate;
            //Veritabanında güncelleme islemi yapacak oldugumuz urunun referans numarasini productToUpdate degiskenine atama islemi yaptik.
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            //Referans numarasi uzerinde propertylere erisip arayuzden gelen yeni guncel bilgileri atama islemi yaptik.
            productToUpdate.ProductName= product.ProductName;   
            productToUpdate.UnitPrice= product.UnitPrice;   
            productToUpdate.UnitsInStock= product.UnitsInStock; 
            productToUpdate.CategoryId= product.CategoryId; 
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // Where metodu icerisindeki ifadedeki kosullari saglayan degerleri yeni bir liste yapip dondurme islemi yapar.
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
