using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Brand")]
        
        //public void Post(Product product)
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //    }
        //}
    }
}
