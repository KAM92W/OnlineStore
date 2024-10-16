using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Model> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Models.ToList();
            }
        }
    }
}
