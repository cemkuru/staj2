using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Models
{
    public class JobAddViewModel
    {
        public Job Job { get; set; }

        public Company Company { get; set; }

        public int CompanyID { get; set; }

        public List<Company> Companies { get; set; }
    }
}
