namespace DataBase
{
    public class Products
    {
        private int id;
        private string Name;
        public Categories ProductCategory { get; set; }
        public Brands ProductBrand { get; set; }
        public Models ProductModels { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Products(int ProductId, string ProductName)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
        }
        public List<Properties> Properties { get; set; }
    }
}
