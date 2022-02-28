using FluentValidation;
using HMBusiness.Abstract;
using HMBusiness.Constants;
using HMBusiness.ValidationRules.FluentValidation;
using HMCore.Aspects.Autofac.Validation;
using HMCore.CrossCuttingConcerns;
using HMCore.Utilities.Business;
using HMCore.Utilities.Results;
using HMDataAccess.Abstract;
using HMEntities.Concrete;
using HMEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        /*
             ProductManager sinifimiz tetiklendiginde verilerimizi getirmek icin constructor tanimladik.
             HMDataAccess katmanimizda tanimli olan verilerimizi getirmek icin IProductDal interfacemizi tanimladik.
             Entity framework sınıfını cağırmamamızın sebebi ORM teknolojilerimizi değiştirme durumuna karşı yeniden bu kısımlari düzenlememek için interface uzerinden tanimladik.
         
             ProductManager içerisindeki metotlarımızın her birinin kendine özel iş kuralları tanımlanabilir.(Bunlar aynı isime sahip ürün olamaz, Bir kategoride 10 dan fazla ürün olamaz gibi.)
             Ama biz bu iş kurallarının metotlarını, bu metot içerisinde tanımlamayız. ProductManager sınıfının en altında bu iş kurallarımızı tanımlarız.
             Çünkü tüm bu kuralları aynı metot içerisinde tanımlarsak çok karmaşık bir hale dönüşür. O yüzden en altta tanımlayıp o metodu çağırabiliriz.
             Kullanmış olduğumuz her iş kuralı metot için doğrulama işlemlerini ayrı ayrı yaparsakta çok karmaşık bir hale dönüşebilir. O yüzden iş kurallarımızın doğruluğunu kontrol ettiğimiz
             bir BusinessRuless sınıfı tanımlayıp onun içerisinde Run metodu ile işlemlerimizin başarılı olup olmama durumunu kontrol edeceğiz. 
             Bu metot başarılı olmayan metotları geri döndürecek eğer başarılı ise de null değer döndürecek. Bizde bu işlem sonucu result değişkeni içerisine atayıp kontrol edeceğiz.
        */
        IProductDal _productDal;
        ICategoryService _categoryService;          // Bir managerın kendi dal' ı hariç başka bir dalı ona enjekte edemeyiz. Fakat yeni enjekte edeceğimiz dalın Service'ni enjekte edebiliriz.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService; 
        }


        [ValidationAspect(typeof(ProductValidator))]        // Add metodunu ProductValidator'da tanımlı kuralları kullanarak ValidationAspect ile doğrulama işlemi yap komutunu tanımlama işlemi yaptık.
        public IResult Add(Product product)
        {
            // Aşağıda tanımlamış olduğumuz iş kurallarımızı bu şekilde Run metoduna parametre olarak gönderip doğruluğunu kontrol etme işlemleri yaparız.
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExits(product.ProductName), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            // Secilen kategoriye gore urunleri listeleyen metodumuzun govdesini tanimladik.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        // Herhangi bir metot ile ilgili iş kuralı tanımlarken kuralımız diğer servislerde kullanılmayacak bir kural ise burada private erişim belirteci ile tanımlarız. Sadece bu sınıfta kullanılır.
        // İş kurallarımızı IResult olarak tanımlamış olduğumuza dikkat edelim.Çünkü bize data lazım değil sadece işlemimizin sonucu lazım.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExits(string productName)  // Aynı isime sahip ürünün olup olmamasını sorgulayan metodumuz.
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();       // Any metodu dizideki değerlerin belirlenen koşullara göre koleksiyonda olup olmadığı kontrol edilir. Koşula uygun değer var ise True, yok ise False sonucu döner.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            } 
            return new SuccessResult();
        }

        // Kategori sayısı 15 den fazla ise ürün ekleme işlemi durdurma işlemi yapıyoruz. 
        // Normalde farklı bir servisi kullanarak tanımlamış olduğumuz bu tarz metotları o servisin manager'ında(CategoryManager) tanımlama işlemi yaparız.
        // Fakat bu metot ürünü ilgilendiren bir iş kuralı olduğu için ProductManager içerisinde tanımlama işlemi yaparız.
        private IResult CheckIfCategoryLimitExceded()   
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count()>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();    
        }
    }
}
