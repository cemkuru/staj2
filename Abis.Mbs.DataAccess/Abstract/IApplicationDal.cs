﻿using Abis.Core.DataAccess;
using Abis.Mbs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.DataAccess.Abstract
{
    public interface IApplicationDal : IEntityRepository<Application>
    {
        List<Application> GetMany();

    }
}

