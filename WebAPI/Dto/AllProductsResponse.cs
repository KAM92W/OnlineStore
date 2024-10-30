using DataBase.Models;

namespace WebAPI.Dto
{
    public class AllProductsResponse
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public IEnumerable<Category> Category{ get; set; } = Array.Empty<Category>();
        //public int Brand { get; set; }
        //public int Model { get; set; }
        //public int Price { get; set; }
        //public IEnumerable<Property> Properties { get; set; } = Array.Empty<Property>();
    }
}
