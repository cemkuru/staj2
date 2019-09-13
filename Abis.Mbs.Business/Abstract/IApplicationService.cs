using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
    public interface IApplicationService
    {
        List<Application> GetAll();

        void Add(Application announcement);
        void Update(Application announcement);
        void Delete(int applicationId);
        Application GetById(int applicationId);
        //List<Application> GetMany();





    }
}
