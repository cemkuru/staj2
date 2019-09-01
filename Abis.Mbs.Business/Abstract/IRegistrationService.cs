using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
    public interface IRegistrationService
    {

        List<REGISTRATION> GetAll();

        void Add(REGISTRATION registration);
        void Update(REGISTRATION registration);
        void Delete(int registerId);
        REGISTRATION GetById(int registerId);

    }
}
