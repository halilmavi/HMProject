using HMCore.DataAccess;
using HMEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMDataAccess.Abstract
{
    
    public interface ICategoryDal : IEntityRepository<Category>
    {
       
    }
}
