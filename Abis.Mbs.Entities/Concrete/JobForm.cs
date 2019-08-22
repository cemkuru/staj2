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
        public int ApplicationID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public DateTime? StartingDate { get; set; }

        [Required]
        public string Letter { get; set; }

        [Required]
        public string Resume { get; set; }


    }
}
