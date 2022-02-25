using FluentValidation;
using HMBusiness.Abstract;
using HMBusiness.Constants;
using HMBusiness.ValidationRules.FluentValidation;
using HMCore.Aspects.Autofac.Validation;
using HMCore.CrossCuttingConcerns;
using HMCore.Utilities.Results;
using HMDataAccess.Abstract;
using HMEntities.Concrete;
using HMEntities.DTOs;
using System;
using System.Collections.Generic;

namespace HMBusiness.Concrete
{    
    public class ProductManager : IProductService
    {
        // ProductManager sinifimiz tetiklendiginde verilerimizi getirmek icin constructor tanimladik.
        // HMDataAccess katmanimizda tanimli olan verilerimizi getirmek icin IProductDal interfacemizi tanimladik.
        // Entity framework sınıfını cağırmamamızın sebebi ORM teknolojilerimizi değiştirme durumuna karşı yeniden bu kısımlari düzenlememek için interface uzerinden tanimladik.
        
        IProductDal _productDal; 
        public ProductManager(IProductDal productDal)       
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]        // Add metodunu ProductValidator'da tanımlı kuralları kullanarak ValidationAspect ile doğrulama işlemi yap komutunu tanımlama işlemi yaptık.
        public IResult Add(Product product)
        {        
            _productDal.Add(product);
            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll() 
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>>GetAllByCategoryId(int id)
        {
            // Secilen kategoriye gore urunleri listeleyen metodumuzun govdesini tanimladik.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
    