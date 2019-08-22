using Abis.Core.DataAccess;
using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.DataAccess.Abstract
{
    public interface IJobFormDal : IEntityRepository<JobForm>
    {
    }
}
