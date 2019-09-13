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
    public class EfApplicationDal : EfEntityRepositoryBase<Application, MbsContext>, IApplicationDal
    {
        public List<Application> GetMany()
        {
            using (var context = new MbsContext())
            {
                return context.Set<Application>().Include(x => x.Job).ToList();
            }
        }
    }
}