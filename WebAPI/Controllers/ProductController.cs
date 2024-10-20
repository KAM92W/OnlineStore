using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
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
                    //Picture = product.PictureLink,
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

        //public IActionResult UploadFile([FromForm] FileUploadModel model)
        //{
        //    var folderName = Path.Combine("wwwroot", "images");
        //    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //    var fileName = model.File.FileName;
        //    var fullPath = Path.Combine(pathToSave, fileName);
        //    var dbPath = Path.Combine(folderName, fileName);
        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        model.File.CopyTo(stream);
        //    }
        //    return Ok(new { dbPath });
        //}
    }
}
