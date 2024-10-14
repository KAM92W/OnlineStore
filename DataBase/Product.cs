namespace DataBase
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public List<Property> Properties { get; set; }
    }
}
