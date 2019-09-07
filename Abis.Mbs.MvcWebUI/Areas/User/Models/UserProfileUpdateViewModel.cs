using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Models
{
    public class UserProfileUpdateViewModel : UserProfile
    {
        
        public CustomIdentityUser CustomIdentityUser { get; set; }

        public UserProfile UserProfile { get; set; }

        public int DepId   { get; set; }

        public int LanguageID { get; set; }

        public List<Department> Departments { get; set; }

        public List<Language> Languages { get; set; }
    }
}
