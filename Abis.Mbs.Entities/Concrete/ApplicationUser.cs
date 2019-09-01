using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abis.Mbs.Entities.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        // Since this property is public we need to override it
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
