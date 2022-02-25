using HMCore.DataAccess;
using HMEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMDataAccess.Abstract
{
    // IEntityRepository interfaceni kalitim olarak verirken Category olarak parametresini tanimliyoruz. CRUD islemlerini yaparken Category'e gore yapmasını yapılandırdık.
    public interface ICategoryDal : IEntityRepository<Category>
    {
       
    }
}
