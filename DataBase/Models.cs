namespace DataBase
{
    public class Models
    {
        private int id;
        private string name;
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public Models (int ModelId, string ModelName )
        {
            this.ModelId = ModelId;
            this.ModelName = ModelName;
        }
        public List<Products> Products { get; set; }
    }
}
