using System.ComponentModel;

namespace DataBase
{
    public class Properties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}
