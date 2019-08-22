using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
   public class Job :IEntity
    {
        public int JobID { get; set; }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }
    }
}
