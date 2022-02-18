using FluentValidation; // Doğrulama işlemlerini yapabilmek için FluentValidation namespace'ni sınıfımıza dahil ediyoruz.
using HMEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBusiness.ValidationRules.FluentValidation
{
    // Product 
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Product tablosundaki nesnelerimiz ile ilgili doğrulama kurallarımızı burada tanımlama işlemi yaptık.
            RuleFor(p => p.ProductName).NotEmpty();         // Ürün ismi boş olamaz.
            RuleFor(p => p.ProductName).MinimumLength(2);   // ürün ismi 2 karakterden az olamaz.
            RuleFor(p => p.UnitPrice).NotEmpty();           // Ürün fiyatı boş olamaz.
            RuleFor(p => p.UnitPrice).GreaterThan(0);       // Ürün fiyatı 0' dan büyük olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // Spesifik kurallarda yazabiliriz. İçecek ürünlerinin fiyatı 10 tl'ye eşit ve üzeri olması gerekir.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");   // Kendi kurallarımızı da tanımlayabiliriz.Mesela ürün ismi A harfi ile başlamalı gibi. Must metoduna parametre olarak kural olan metodumuzu gönderiyoruz.
        }

        private bool StartWithA(string arg)
        {
            // arg parametresi ProductName'nin değerini göndermektedir. Gelen bu degeri C# 'ın kendi metodu ile sorguluyoruz. A harfi ile başlıyorsa true değilse false döndürüyor.
            return arg.StartsWith("A");
        }
    }
}
