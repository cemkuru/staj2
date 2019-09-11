using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companytDal)
        {
            _companyDal = companytDal;
        }

        public void Add(Company company)
        {
            _companyDal.Add(company);
        }

        public void Delete(int companyId)
        {
            _companyDal.Delete(new Company {CompanyID = companyId });
        }

        public List<Company> GetAll()
        {
            return _companyDal.GetList();
        }

        public Company GetById(int companyId)
        {
            return _companyDal.Get(p => p.CompanyID == companyId);
        }

        public void Update(Company company)
        {
            _companyDal.Update(company);
        }
    }
}
