using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class ApplicationAddViewModel
    {
        public List<Application> Applications { get; set; }
        public Application Application { get; set; }

        public CustomIdentityUser CustomIdentityUser { get; set; }
        public string  DepertmentName { get; set; }

        public Job Job { get; set; }
    }
}
