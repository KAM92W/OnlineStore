namespace WebAPI.Dto
{
    public class ProductName
    {
        public IFormFile File { get; set; }
        //public string PictureLink { get; set; }
        public int BrandId { get; set; }
        public int CategoryId {  get; set; }
        public int ModelId { get; set; }
        public int PriceId { get; set; }
    }
}
