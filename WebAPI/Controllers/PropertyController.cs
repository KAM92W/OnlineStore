using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

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

    [HttpGet("{id}")]
    public ActionResult <PropertyResponse> GetProperty(int id)
    {
        using (var db = new ApplicationContext())
        {
            var property = db.Properties
                .FirstOrDefault(x => x.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            var response = new PropertyResponse
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description,
                Product = property.ProductId,
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public ActionResult<PropertyCreate> Post(PropertyCreate propertyname)
    {
        using (var db = new ApplicationContext())
        {
            var entity = new Property
            {
                Name = propertyname.Name,
                Description = propertyname.Description,
                ProductId = propertyname.ProductId,
            };
            db.Properties.Add(entity);
            db.SaveChanges();
            return Ok();
        }
    }
}
