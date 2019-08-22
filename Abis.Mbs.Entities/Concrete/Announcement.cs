using Abis.Core.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Abis.Mbs.Entities.Concrete
{
    public class Announcement : IEntity
    {
        
        public int AnnouncementId { get; set; }
       
        [Required]
        public string ATitle { get; set; }
       
        [Required]
        public string ADescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ACreateDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        //public DateTime? ACreateDate2 { get; set; }

        //[Display(Name = "APhoto")]
        //public byte[] APhoto { get; set; }



        //[Display(Name = "APhoto")]
        //public byte[] APhoto { get; set; }
        //public bool IsActive { get; set; }



    }
}
