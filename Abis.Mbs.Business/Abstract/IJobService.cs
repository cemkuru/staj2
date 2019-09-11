using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abis.Mbs.Entities.Concrete;


namespace Abis.Mbs.Business.Abstract
{
    public interface IJobService
    {
        List<Job> GetAll();
        void Add(Job job);
        void Update(Job job);
        void Delete(int JobId);
        Job GetById(int JobId);

        //List<Job> GetMany(Expression<Func<Job, bool>> where, params string[] include);

        //List<Job> GetMany(params string[] include);

        //List<Job> GetMany(Expression<Func<Job, bool>> where);
    }
}
