using HMBusiness.Abstract;
using HMBusiness.Concrete;
using HMDataAccess.Concrete.EntityFramework;
using HMEntities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/*
     Bir controller sınıfının controller olabilmesi için ControllerBase sınıfını kalıtım olarak alması gerekir.
     ProductController sınıfı üzerinden tanımlamış olduğumuz "  [Route("api/[controller]")] , [ApiController]  " 'lar birer attribute'dur.
     Bu attribute'lar class için tanımlamış oldumuz kuralların uygulanmasını sağlarlar. Birer imza görevi görürler. 
     Route ile bize nasıl istekte bulunacağını tanımlıyoruz.
     ApiController ile de sınıfımıza controller'ın uygulanması ve yapılanması gereken kuralları tanımlıyoruz.
*/

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
           Loosely coupled( Gevşek bağlılık. Burada bağımlılıgımız soyuta bagimliliktir.)
           ProductsController sınıfı tetiklendiğinde verileri getirmek için HMBusiness.Concrete klasörü içerisinde ProductManager sınıfını new'lememiz gerekir.
           Bu durum bağımlılık yaratacağı için yine bu sınıfa kalıtım olarak aktarılan IProductService interface'i ProductManager somut sınıfının referans adresini tuttuğu için
           onu kullanarak  new'leme yapmadan bu sınıfın operasyonlarına erişim sağlayabiliriz. 
           Burada tanimlamis oldugumuz constructorimiza parametre olarak Startup icerisinde ConfigureService icerisinde tanimlamis oldugumuz AddSingleton metodu uzerinden ProductManager'i gonderiyoruz.
        */
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]  // HttpGet attribute ile tanimlamis oldugumuz Get metodu ile serverdan verilerimizi çekmek için kullanırız.
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
             
            return BadRequest(result);
        }
         

        [HttpPost("add")] // HttpPost attribute'nu servere verilerimizi gonderme işlemi yaparken tanımlama yaparız.
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
 