using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Business.Abstract
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAll();

        void Add(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(int announcementId);
        Announcement GetById(int announcementId);




    }
}
