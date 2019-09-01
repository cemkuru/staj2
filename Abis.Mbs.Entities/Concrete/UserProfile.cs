using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class UserProfile : IEntity
    {
        [Key]
        public int ID { get; set; }

        public string UserId { get; set; }

        public int DepId { get; set; }

        public string SKills { get; set; }

        public string CV { get; set; }

        public string Project { get; set; }


        //public byte ProfileImage { get; set; }

    }
}
