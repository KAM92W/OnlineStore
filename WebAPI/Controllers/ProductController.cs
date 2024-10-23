using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        using (var db = new ApplicationContext())
        {
            return db.Products.ToList();
        }
    }

    [HttpPost]
    public void Post(ProductName product)
    {
        var folderName = Path.Combine("wwwroot", "images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        var fileName = product.File.FileName;
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine("images", fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            product.File.CopyTo(stream);
        }

        using (var db = new ApplicationContext())
        {
            var entity = new Product
            {
                Picture = dbPath,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelId = product.ModelId,
                PriceId = product.PriceId,
                Properties = []
            };
            db.Products.Add(entity);
            db.SaveChanges();
        }
    }
}
