using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Models
{
    public class JobFormAddViewModel
    {
        public JobForm JobForm { get; set; }

        public CustomIdentityUser CustomIdentityUser { get; set; }

        public Job Job { get; set; }

        public List<Job> Jobs { get; set; }

        public List<Company> Companies { get; set; }

    }
}
