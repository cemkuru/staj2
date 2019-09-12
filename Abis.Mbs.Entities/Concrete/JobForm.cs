using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class JobForm: IEntity
    {
        [Key]
        public int ID { get; set; }

        public string UserId { get; set; }

        public int  JobID { get; set; }

        public int CompanyID { get; set; }

        public Company Company { get; set; }

        public Job Job { get; set; }




    }
}
