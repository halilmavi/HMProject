using HMEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMDataAccess.Concrete.EntityFramework
{
  
    /*
        NorthwindContext class'i icerisinde veritabani tablolar ile projemizde bulunan ana class'lar yani gercek class'lari iliskilendirdigimiz yerdir.
        NorthwindContext'ine DbContext class'i kalitim olarak eklememiz gerekir. Çünkü ;
            DbContext bir classtır ve Entity Framework’un olmazsa olmazıdır. DBContext veritabanımızla uygulamamız arasında sorgulama, güncelleme, silme gibi
                işlemleri yapmamız için olanak sağlar.Entity framework içinde yer alan bu class aslında her bir varlık yani entity veya her bir model için DBSet barındırır.
        Yani veritabanı içinde yer alan verilerimizle alakalı olarak her türlü süreçte iletişimimizi sağlayan bir classtır.

        DbContext bize ne sağlar?

        Database bağlantısının yönetimi,
        Modellerimiz ve database ilişkilerinin yönetimi,
        Database sorguları yönetimi,
        Database veri kaydetme işlemleri,
        Değişikliklerin izlenebilmesi,
        Transaction (işlem) yönetimi,
        Caching (Önbellek işlemleri)

    */

    public class NorthwindContext : DbContext
    {
        // OnConfiguring metodu ile uygulamamızın hangi veritabanina baglanacagini tanimlama islemi yaptik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        // DbSet ile veritabani ile projemizde yer alan nesne arasindaki iliskiyi kuracagiz.
        // Projemde yer alan Product nesnesini veritabaninda yer alan Products nesnesi ile iliskilendir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }




    }
}
