using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, MbsContext>, ICategoryDal
    {

    }
}