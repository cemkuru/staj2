﻿using Abis.Mbs.Entities.Concrete;
using System.Collections.Generic;

namespace Abis.Mbs.MvcWebUI.Models
{
    public class AnnouncementListViewModel
    {
        public List<Announcement> Announcements { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
        public List<DepartmentModel> departmentModels { get; set; }

    }
}
