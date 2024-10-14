namespace DataBase
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public Categories Category { get; set; }
        public Brands Brand { get; set; }
        public Models Model { get; set; }
        public List<Properties> Properties { get; set; }
    }
}
