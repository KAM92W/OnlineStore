using DataBase.Models;

namespace WebAPI.Dto
{
    public class AllProductsResponse
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Price Price { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
}
