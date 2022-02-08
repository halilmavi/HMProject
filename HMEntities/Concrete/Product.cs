using HMCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMEntities.Concrete
{
    // Propertylerimizi tanimlamis olduğumuz sınıflarımızı sade bir sekilde bırakmayiz. Kalitim, interface vs. soyutlama işlemlerine tabi tutmamiz gerekir.
    public class Product:IEntity    
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock  { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
