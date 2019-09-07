using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class Language : IEntity
    {
        public int LanguageID { get; set; }

        public string LanguageName { get; set; }

    }
}
