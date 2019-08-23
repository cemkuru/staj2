using Abis.Mbs.Entities.Concrete;
using System.Collections.Generic;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class AnnouncementListViewModel
    {
        public List<Announcement> Announcements { get; internal set; }
    }
}
