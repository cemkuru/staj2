using System.Collections.Generic;
using Abis.Mbs.Entities.Concrete;

namespace Abis.Mbs.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}