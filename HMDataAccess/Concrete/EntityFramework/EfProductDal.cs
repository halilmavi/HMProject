using HMCore.DataAccess.EntityFramework;
using HMDataAccess.Abstract;
using HMEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/*
 
     EfProductDal 'a kalitim olarak eklemis oldugumuz IProductDal interfacemiz ICategoryDal, IOrderDal ve ICustomerDal beraber 4'nu IEntityRepository
     icerisinde ortak bulunan veritabani islemleri icin tanimlamis oldugumuz metotlarimizin imzalarini tanimlamistik. IEntityRepository interfacemizi Core katmaninda
     DataAccess klasoru icerisinde tanimladik. Tanimlamis oldugumuz bu interfacemizi  EntityFramework klasoru  icerisinde tanimlamis oldugumuz EfEntityRepositoryBase
     class'ina kalitim olarak ekliyoruz.Olusturmus oldugumuz EfEntityRepositoryBase sinifta generic bir yapi tanimlayip parametrelerini TEntity,TContext olacak 
     sekilde tanimliyoruz. Parametreleri bu sekilde tanimlamamizin sebebi projemizdeki tüm uygulamalar bu metotlari kullanacagi icin ortak bir tur tanimlamamiz gerekiyor.

 */

namespace HMDataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase <Product, NorthwindContext> , IProductDal
    {  
       
    }
}
