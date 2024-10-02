namespace DataBase
{
    public class Brands
    {
        private int id;
        private string name;
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public Brands(int BrandId, string BrandName)
        {
            this.BrandId = BrandId;
            this.BrandName = BrandName;
        }
        public List<Products> Products { get; set; }
    }
}
