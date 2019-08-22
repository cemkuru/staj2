using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Models
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
