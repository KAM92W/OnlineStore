using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public ActionResult<AllProductsResponse> GetAllProduct()
    {
        using (var db = new ApplicationContext())
        {
            var entity = db.Products;
            var allProducts = new AllProductsResponse();
            allProducts.Id = entity.
            return ;
        }
    }

    [HttpGet("{id}")]
    public ActionResult<ProductResponse> GetProduct(int id)
    {
        using (var db = new ApplicationContext())
        {
            var product = db.Products
                .Include(x => x.Properties)
                .FirstOrDefault(x => x.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            var response = new ProductResponse
            {
                Id = product.Id,
                Picture = product.Picture,
                Category = product.CategoryId,
                Brand = product.BrandId,
                Model = product.ModelId,
                Price = product.PriceId,
                Properties = product.Properties
                    .Select(x => new Property
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ProductId = x.ProductId,
                    })
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public ActionResult<ProductCreate> Post(ProductCreate product)
    {
        var folderName = Path.Combine("wwwroot", "images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        var fileName = product.File.FileName;
        var fullPath = Path.Combine(pathToSave, fileName);

        var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fullPath);
        var newFullPath = Path.Combine(pathToSave, newFileName);

        var dbPath = Path.Combine("images", newFileName);

        using (var stream = new FileStream(newFullPath, FileMode.Create))
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
            return Ok();
        }
    }
}
