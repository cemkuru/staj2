using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Core.DataAccess;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Custom Operations
    }
}
