using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class UserProfileAddViewModel : UserProfile
    {
        public UserProfile UserProfile { get; set; }
        public Department Department { get; set; }
    }
}
