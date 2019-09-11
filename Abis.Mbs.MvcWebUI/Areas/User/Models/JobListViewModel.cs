using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class JobListViewModel
    {
        public JobListViewModel()
        {
            Jobs = new List<Job>();
            Company = new Company();
        }
        public List<Job> Jobs { get; internal set; }

        public Company Company { get; set; }

        public List<Company> Companies { get; set; }


    }
}
