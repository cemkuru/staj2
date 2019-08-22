using System.Collections.Generic;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}