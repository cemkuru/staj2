using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abis.Mbs.Business.Concrete
{
    public class JobManager : IJobService
    {
        private IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }
        public void Add(Job job)
        {
            _jobDal.Add(job);
        }

        public void Delete(int jobId)
        {
            _jobDal.Delete(new Job { JobID = jobId });
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetList();
        }

        public Job GetById(int jobId)
        {
            return _jobDal.Get(p => p.JobID == jobId);
        }

        public void Update(Job job)
        {
            _jobDal.Update(job);
        }
       

        
    }
}
