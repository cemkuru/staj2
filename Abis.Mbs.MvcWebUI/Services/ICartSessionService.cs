using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
