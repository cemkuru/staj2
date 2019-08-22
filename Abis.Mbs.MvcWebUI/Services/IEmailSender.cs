using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Services
{
   public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
