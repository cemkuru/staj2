using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class UserProfileAddViewModel 
    {
        public UserProfile UserProfile { get; set; }
        public Department Department { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
