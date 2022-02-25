using HMCore.DataAccess.EntityFramework;
using HMDataAccess.Abstract;
using HMEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMDataAccess.Concrete.EntityFramework
{
    /*
         EfCategoryDal 'a kalıtım olarak eklemiş olduğumuz ICategoryDal interfacemiz IProductDal ve ICustomerDal beraber 3'nu IEntityRepository
         içerisinde ortak bulunan veritabanı işlemleri için tanımlamış olduğumuz metotlarımızın imzalarını tanımlamıstık. IEntityRepository interfacemizi Core katmanında
         DataAccess klasörü içerisinde tanımladık. Tanımlamış oldugumuz bu interfacemizi  EntityFramework klasoru  icerisinde tanimlamis oldugumuz EfEntityRepositoryBase
         class'ina kalitim olarak ekliyoruz.Olusturmus oldugumuz EfEntityRepositoryBase sinifta generic bir yapi tanimlayip parametrelerini TEntity,TContext olacak 
         sekilde tanimliyoruz. Parametreleri bu sekilde tanimlamamizin sebebi projemizdeki tüm uygulamalar bu metotlari kullanacagi icin ortak bir tur tanimlamamiz gerekiyor.
    */
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}
