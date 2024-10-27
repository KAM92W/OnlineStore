using DataBase.Models;

namespace WebAPI.Dto
{
    public class PropertyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Product { get; set; }
    }
}
