using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.DataAccess.Concrete.EntityFramework
{
     public class EfJobFormDal: EfEntityRepositoryBase<JobForm, MbsContext>, IJobFormDal
    {

    }
}
