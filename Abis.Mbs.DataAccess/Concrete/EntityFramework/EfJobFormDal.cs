using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abis.Mbs.DataAccess.Concrete.EntityFramework
{
    public class EfJobFormDal : EfEntityRepositoryBase<JobForm, MbsContext>, IJobFormDal
    {
        public List<JobForm> GetAllWithIncludeJob()
        {
            using (var context = new MbsContext())
            {
                return context.Set<JobForm>().Include(x => x.Job).Include(x => x.Company).ToList();
            }
        }
    }
}
