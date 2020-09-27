namespace StoreFront.UI.MVC.Models
{
    public class ShopViewModel
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}