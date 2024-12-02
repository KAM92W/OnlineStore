namespace WebAPI.Dto;

public class ProductCreate
{
    public IFormFile File { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public int ModelId { get; set; }
    public int PriceId { get; set; }
}
