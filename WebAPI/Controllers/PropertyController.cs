using DataBase;
using DataBase.Models;
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

    [HttpPost]
    public void Post(PropertyName propertyname)
    {
        using (var db = new ApplicationContext())
        {
            var entity = new Property
            {
                Name = propertyname.Name,
                Description = propertyname.Description,
                ProductId = propertyname.ProductId,
            };
        }
    }
}
