using SF.DATA.EF;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.UI.MVC.Models
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