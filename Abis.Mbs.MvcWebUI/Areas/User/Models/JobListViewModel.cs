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
        }
        public List<Job> Jobs { get; internal set; }
    }
}
