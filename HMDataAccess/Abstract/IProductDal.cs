﻿using HMCore.DataAccess;
using HMEntities.Concrete;
using HMEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMDataAccess.Abstract
{
    // Product ve Category'de Silme, guncelleme, ekleme, listeleme islemleri ortak islemler oldugu icin imzalarını IEntityRepository interfacemizde tanımlarız
    //   ve bu interface'i IProductDal'a kalitim olarak veriyoruz.
    // Ürünlerle ilgili operasyonları IEntityRepository interfacesine gonderecek olduğumuz parametreyi Product olarak tanimliyoruz.
    // Bu durumda IEntityRepository interface'sini hangi sinifa kalitim olarak ekliyorsak o sınıfın turunde parametre gonderme islemi yapmamız gerekir.
    // Interface'ler varsayılan olarak internal'dir. Interface'in icerisindeki operasyonlari public'tir.
    // IProductDal icerisinde urun ile ilgili sadece ürüne özel tarzda operasyonlarimizi tanimlama islemi yapariz.
    // IProductDal a ozgu olarak ProductDetailDto list koleksiyon tipi ile listeleme islemi yapacağız. 

    public interface IProductDal:IEntityRepository<Product>
    {  
        List<ProductDetailDto> GetProductDetails();
    }
}
