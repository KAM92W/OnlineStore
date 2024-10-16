using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Properties.ToList();
            }
        }
    }
}
