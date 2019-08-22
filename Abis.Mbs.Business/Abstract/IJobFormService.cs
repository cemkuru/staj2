using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
    public interface IJobFormService
    {
        List<JobForm> GetAll();

        void Add(JobForm jobform);
        void Update(JobForm jobform);
        void Delete(int Id);
        JobForm GetById(int Id);
    }
}
