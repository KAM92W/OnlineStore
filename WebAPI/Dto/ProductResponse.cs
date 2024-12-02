using DataBase.Models;

namespace WebAPI.Dto
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public int Category { get; set; }
        public int Brand { get; set; }
        public int Model { get; set; }
        public int Price { get; set; }
        public IEnumerable<Property> Properties { get; set; } = Array.Empty<Property>();
    }
}