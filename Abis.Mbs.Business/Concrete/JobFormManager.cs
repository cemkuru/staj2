using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
    public class JobFormManager : IJobFormService
    {
        private IJobFormDal _jobformDal;

        public JobFormManager(IJobFormDal jobFormDal)
        {
            _jobformDal = jobFormDal;
        }

        public void Add(JobForm jobform)
        {
            _jobformDal.Add(jobform);
        }

        public void Delete(int Id)
        {
            _jobformDal.Delete(new JobForm { ApplicationID = Id });
        }

        public List<JobForm> GetAll()
        {
            return _jobformDal.GetList();
        }

        public JobForm GetById(int Id)
        {
            return _jobformDal.Get(p => p.ApplicationID == Id);

        }

        public void Update(JobForm jobform)
        {
            _jobformDal.Update(jobform);

        }
    }
}
