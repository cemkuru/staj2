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
        public string Department { get; set; }

        [Required]
        public string WorkType { get; set; }

        [Required]
        public string Position { get; set; }


        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        public string Education { get; set; }

        //[Required]
        public string Description { get; set; }

        [Required]
        public string Experience { get; set; }

        [Required]
        public string EducationLevel { get; set; }

        [Required]
        public int CompanyID { get; set; }

        public Company Company { get; set; }



    }
}
