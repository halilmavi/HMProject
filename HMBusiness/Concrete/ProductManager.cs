using HMBusiness.Abstract;
using HMDataAccess.Abstract;
using HMEntities.Concrete;
using HMEntities.DTOs;
using System.Collections.Generic;

namespace HMBusiness.Concrete
{    
    public class ProductManager : IProductService
    {
        // ProductManager sinifimiz tetiklendiginde verilerimizi getirmek icin constructor tanimladik.
        // HMDataAccess katmanimizda tanimli olan verilerimizi getirmek icin IProductDal interfacemizi tanimladik.
        // Entity framework sınıfını cağırmamamızın sebebi ORM teknolojilerimizi değiştirme durumuna karşı yeniden bu kısımlari düzenlememek için interface uzerinden tanimladik.
        
        IProductDal _productDal; 
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll() 
        {
            return _productDal.GetAll();
           
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            // Secilen kategoriye gore urunleri listeleyen metodumuzun govdesini tanimladik.
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
  