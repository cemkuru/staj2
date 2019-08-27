using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Models
{
    public class RegistrationUpdateViewModel
    {
        public string  UserRolId { get; set; }
        public CustomIdentityUser UserIdentity { get; set; }
        public IEnumerable<SelectListItem> Rols { get; set; }
    }
}
