using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
