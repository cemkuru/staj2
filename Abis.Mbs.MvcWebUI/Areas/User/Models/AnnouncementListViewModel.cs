using Abis.Mbs.Entities.Concrete;
using System.Collections.Generic;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class AnnouncementListViewModel
    {
        public List<Announcement> Announcements { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}
