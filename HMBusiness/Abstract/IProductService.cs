using HMEntities.Concrete;
using HMEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBusiness.Abstract
{
    public interface IProductService
    {
        //Product tablosunda tanımlı olan urunlerin hepsini listeleyen metodumuzu tanimlama islemi yaptik.
        List<Product> GetAll();
        // Secmis oldugumuz kategoriye  göre listeleme islemi yapacak olan metodumuz.
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        public List<ProductDetailDto> GetProductDetails();
    }
}
