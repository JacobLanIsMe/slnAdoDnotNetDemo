using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAdoDnotNetDemo.Models
{
    public class CProduct
    {
        public bool IsAddProductInfo = false;
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal productCost { get; set; }
        public int productQty { get; set; }
        public decimal productPrice { get; set; }
    }
}
