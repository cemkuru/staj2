using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class Department:IEntity
    {
        [Key]
        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public int Amount { get; set; }
    }
}
