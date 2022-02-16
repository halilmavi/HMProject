using HMCore.Utilities.Results;
using HMEntities.Concrete;
using HMEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 IDataResult ve IResult tanımlamamızdaki temel amaç uygulama için tanımlanan metotların yapmış olduğu işlemlerin başarılı olup olmamasını ve
 bununla ilgili bir mesaj döndürmesini istediğimiz için tanımladık. Bunların direkt metotların içesinde tanımlayabilirdik. Fakat bir metot 
 sadece bir işlevi yapmalı(hem ürün döndürüp hem de yaptığı işlem ile ilgili mesaj döndürme ve durum sonucu döndürme işlemi yapmamalı.) o yüzden Utilities klasöründe 
 Results klasörü içerisinde işlem sonucu ve işlem durumları için farklı sınıflar tanımladık.
 IResult'ı  sadece işlem sonucu ve mesaj verecek şekilde tanımladık fakat bize değer döndürmeyecekler(void).
 IDataResult'ı işlem sonucu, mesajı hem de döndüreceği değeri içermesi için tanımladık.
 Kapsülleme yaparak tek bir generic yapıda hepsini tanımlama işlemi yaptık.
 
 
*/
namespace HMBusiness.Abstract
{ 
    public interface IProductService
    {
        // Product tablosunda tanımlı olan urunlerin hepsini listeleyen metodumuzu tanimlama islemi yaptik.
        IDataResult<List<Product>>GetAll();
        // Secmis oldugumuz kategoriye  göre listeleme islemi yapacak olan metodumuz.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        // Yukarda List ile birden fazla ürünün bilgilerini listeleme islemi yaptığımız için List tanımladık. Ama burda Product türünde tek bir ürünün detayını getireceğimiz list olarak tanımlamadık.
        // GetById nesnesi ile E-ticaret sitesinde bir urune tikladigimizda o urunle ilgili gelen bilgileri sakladigimiz nesnelerimizi bu obje uzerinde saklariz.  
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);

    }
}
