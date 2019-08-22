using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Core.Entities;

namespace Abis.Mbs.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

