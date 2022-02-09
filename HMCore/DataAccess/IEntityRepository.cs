using HMCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.DataAccess
{
    #region Generic_Repository_DesignPattern_Gerekliligi
    /*
        Yazılım uygulamaları genellikle yoğun bir şekilde veritabanı işlemleri gerçekleştiren ekosisteme sahip yapılar olduğundan dolayı,
        ilgili uygulamanın her bir noktasında gerekli veritabanı işlemlerini tekrar tekrar yazmak yerine bu işlemleri tekrar
        kullanılabilirlik prensibi çerçevesinde daha pratik bir şekilde tek seferde yapmamızı sağlayan bir yapılanma geliştirmemiz gerekecektir.
        İşte bu yapılanma Repository sınıfı olacaktır.
    */

    #endregion

    #region Genericlerin_Tip_Guvenligi_Icin_Parametrelerinin_Kısıtlanması
    /* 
     Genericlere parametre olarak gonderilen seyleri kisitlayabiliriz.Yani ICategoryDal ve IProductDal interfacelerine parametre olarak gonderilen nesneleri
     kisitlama islemi yapacagiz ki sadece veritabani nesneleri gonderilebilsin. O yuzden where ile tanimladigimiz ifadeler sahip olan nesneleri parametre olarak alabilecek.
     class   : Referans tipte bir deger yazilabilecegini tanimladik. Deger tipler(int,byte,float) vs yazilmasinin onune gectik.
     IEntity : Burda da IEntity'i ve IEntity  interface'ini implemente eden siniflarin parametre olarak gonderebilecegini tanimladik.
     new     : IEntity'i kosulumuza ekledik cunku onu implemente eden siniflari gondermemiz lazım. Ama interface'in kendisini parametre olarak gondermemiz bir ise  
                yaramayacagi icin new kosulunu da ekledik ki interface'ler new'lenemeyecegi icin parametre olarak gondeirlmesinin onune gecme islemini tanimladik.
    */
    #endregion


    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Expression yapisini filtreleme islemlerinde kullanabilmek icin tanimladik. Yani iş sınıfımızdan parametre olarak gonderilen Linq sorgularını calistirabilmek icin.
        // Kategorilerimizi secitimizde filtreleme islemini yapan metodumuzu Expression yapida tanimladik. filter = null ile filtre vermeden cagirabiliriz.
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Tum datayi istedigimiz icin filtre parametresi gondermedik.
        T Get(Expression<Func<T, bool>> filter); // Tek bir ürün veya nesne hakkinda detayli bilgi alabilmek icin kullanmış oldugumuz metodumuz. Bunda filtre gonderme zorunlulugumuz vardır.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
