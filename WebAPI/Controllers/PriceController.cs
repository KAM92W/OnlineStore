using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Price> Get()
    {
        using (var db = new ApplicationContext())
        {
            return db.Prices.ToList();
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPrice(int id)
    {
        using (var db = new ApplicationContext())
        {
            var price = db.Prices.Find(id);
            var response = new PriceResponse
            {
                Id = price.Id,
                Name = price.Name
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public void Post(PriceName rub)
    {
        using (var db = new ApplicationContext())
        {
            var entity = new Price { Name = rub.Name, Products = [] };
            db.Prices.Add(entity);
            db.SaveChanges();
        }
    }
}
