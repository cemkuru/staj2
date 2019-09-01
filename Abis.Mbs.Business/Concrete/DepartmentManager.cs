using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public void Delete(int depId)
        {
            _departmentDal.Delete(new Department { DepId = depId });
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetList();
        }

        public Department GetById(int depId)
        {
            return _departmentDal.Get(p => p.DepId == depId);
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
