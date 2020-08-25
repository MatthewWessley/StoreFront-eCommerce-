using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StoreFrontLAB.DATA.EF;

namespace StoreFrontLAB.Models
{
    public class ShoppingCartViewModel
    {
        [Range(1, int.MaxValue)]
        public int Qty { get; set; }
        public Product Product { get; set; }
        
        public ShoppingCartViewModel(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }
    }
}