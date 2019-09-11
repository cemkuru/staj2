using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class Company : IEntity
    {
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }
    }
}
