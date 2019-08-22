using System;
using System.Threading.Tasks;

namespace Abis.Mbs.Entities.Concrete
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
