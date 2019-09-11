using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAll();

        void Add(Company company);
        void Update(Company company);
        void Delete(int companyId);
        Company GetById(int companyId);
    }
}
