using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

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

        [HttpPost]
        public void Post(ModelName modelname)
        {
            using (var db = new ApplicationContext())
            {
                var entity = new Model { Name = modelname.Name, Products = [] };
                db.Models.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
