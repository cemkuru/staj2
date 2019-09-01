using System;
using System.Collections.Generic;
using System.Text;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.Business.Abstract
{
    public interface IUserProfileService
    {
        List<UserProfile> GetAll();
        void Add(UserProfile userProfile);
        void Update(UserProfile userProfile);
        void Delete(int Id);
        UserProfile GetById(int Id);
    }
}
