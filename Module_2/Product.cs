namespace ObuvApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public int StockQuantity { get; set; }
        public decimal Discount { get; set; }
        public string ImagePath { get; set; }

        public decimal FinalPrice =>
            Discount > 0 ? Price - (Price * Discount / 100) : Price;
    }
}
