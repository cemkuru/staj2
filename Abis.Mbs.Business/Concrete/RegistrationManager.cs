using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
   public class RegistrationManager : IRegistrationService
    {
        private IRegistrationDal _registrationDal;

        public RegistrationManager(IRegistrationDal registrationDal)
        {
            _registrationDal = registrationDal;
        }
        public void Add(REGISTRATION registration)
        {
            _registrationDal.Add(registration);
        }

        public void Delete(int registerId)
        {
            _registrationDal.Delete(new REGISTRATION { RegisterID = registerId });
        }

        public void Update(REGISTRATION registration)
        {
            _registrationDal.Update(registration);
        }

        public List<REGISTRATION> GetAll()
        {
            return _registrationDal.GetList();
        }

        public REGISTRATION GetById(int registerId)
        {
            return _registrationDal.Get(p => p.RegisterID == registerId);
        }
    }
}
