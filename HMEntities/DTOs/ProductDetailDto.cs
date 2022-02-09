using HMCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMEntities.DTOs
{
    // ProductDetailDto sinifini tanımlamamızın sebebi Ürün ile ilgili bilgiler kısmında CategoryId yerine direkt CategoryName'nin yazmasını istedigimiz için
    // Join islemi yapacağız ve Ürünleri gosterirken kategorisinin adını da ekrana bastıracağız.
    // Bu sınıf bir veritabanı tablosu olmadığı için IEntity interfaceni kalıtım olarak eklemiyoruz. Çünkü bu işlem varolan veritabanı tabloları arasında gerçekleşecek.
    public class ProductDetailDto :IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
