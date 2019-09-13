using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class Application : IEntity
    {
        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }
        
        public int JobID { get; set; }

        public Job Job { get; set; }
        //public Company Company { get; set; }
    }


}
