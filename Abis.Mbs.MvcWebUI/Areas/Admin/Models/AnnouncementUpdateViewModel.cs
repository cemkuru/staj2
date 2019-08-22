using System.Collections.Generic;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Models
{
    public class AnnouncementUpdateViewModel
    {
        public Announcement Product { get; set; }
        public List<Category> Categories { get; set; }
        public Announcement Announcement { get; internal set; }
    }
}