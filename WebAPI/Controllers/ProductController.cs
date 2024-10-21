using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        using (var db = new ApplicationContext())
        {
            var entity = new Product
            {
                Picture = "Should be the link to image here",
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

    [HttpPost("UpLoad"), DisableRequestSizeLimit]
    public async Task<IActionResult> UploadFile([FromForm] ProductName model)
    {
        //if (model.File == null && model.File.Length == 0)
        //{
        //    return BadRequest("Invalid file");
        //}
        var folderName = Path.Combine("wwwroot", "images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //if (!Directory.Exists(pathToSave))
        //{
        //    Directory.CreateDirectory(pathToSave);
        //}
        var fileName = model.File.FileName;
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine(folderName, fileName);
        //if (System.IO.File.Exists(fullPath))
        //{
        //    return BadRequest("file already exist");
        //}
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            model.File.CopyTo(stream);
        }
        return Ok(new { dbPath });
    }
}
