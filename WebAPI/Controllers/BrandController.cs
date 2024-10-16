using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Brands.ToList();
            }
        }
        [HttpPost]
        public void Post (Brand brand)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Brands.Add(brand);
                db.SaveChanges();
            }
        }
    }
}
