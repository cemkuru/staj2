using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class UserProfileListViewModel
    {
        public UserProfileListViewModel()
        {
            UserProfiles = new List<UserProfile>();
        }

        public List<UserProfile> UserProfiles { get; internal set; }

    }
}
