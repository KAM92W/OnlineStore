using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

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

    [HttpGet("{id}")]
    public ActionResult <ModelResponse> GetModel(int id)
    {
        using (var db = new ApplicationContext())
        {
            var model = db.Models
                .FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            var response = new ModelResponse
            {
                Id = model.Id,
                Name = model.Name
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public ActionResult<ModelCreate> Post(ModelCreate modelname)
    {
        using (var db = new ApplicationContext())
        {
            var entity = new Model 
            { 
                Name = modelname.Name, 
                Products = [] 
            };
            db.Models.Add(entity);
            db.SaveChanges();
            return Ok();
        }
    }
}
