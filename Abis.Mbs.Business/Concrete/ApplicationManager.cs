using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Abis.Mbs.Business.Concrete
{
    public class ApplicationManager : IApplicationService
    {
        private IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }
        public void Add(Application application)
        {
            _applicationDal.Add(application);
        }

      

        public void Delete(int applicationId)
        {
            _applicationDal.Delete(new Application { ID = applicationId });
        }

        public List<Application> GetAll()
        {
            return _applicationDal.GetList();
        }

        public Application GetById(int applicationId)
        {
            return _applicationDal.Get(p => p.ID == applicationId);
        }

        //public List<Application> GetMany()
        //{
        //    return _applicationDal.GetMany();
        //}

        public void Update(Application announcement)
        {
            _applicationDal.Update(announcement);
        }
    }
}
