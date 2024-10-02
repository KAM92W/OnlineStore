namespace DataBase
{
    public class Categories
    {
        private int id;
        private string name;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Categories(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
        }
        public List<Products> Products { get; set; }
    }
}