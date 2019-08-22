using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MbsContext>, IProductDal
    {

    }
}
