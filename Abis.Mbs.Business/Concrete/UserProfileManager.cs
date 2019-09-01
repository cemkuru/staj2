using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Concrete
{
    public class UserProfileManager : IUserProfileService
    {
        private IUserProfileDal _userProfileDal;

        public UserProfileManager(IUserProfileDal userProfileDal)
        {
            _userProfileDal = userProfileDal;
        }
        public void Add(UserProfile userProfile)
        {
            _userProfileDal.Add(userProfile);
        }

        public void Delete(int Id)
        {
            _userProfileDal.Delete(new UserProfile { ID = Id });
        }

        public List<UserProfile> GetAll()
        {
            return _userProfileDal.GetList();
        }

        public UserProfile GetById(int Id)
        {
            return _userProfileDal.Get(p => p.ID == Id);
        }

        public void Update(UserProfile userProfile)
        {
            _userProfileDal.Update(userProfile);
        }
    }
}
