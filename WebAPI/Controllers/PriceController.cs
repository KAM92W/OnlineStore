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
    public ActionResult <PriceResponse> GetPrice(int id)
    {
        using (var db = new ApplicationContext())
        {
            var price = db.Prices
                .FirstOrDefault(x => x.Id == id);
            if (price == null)
            {
                return NotFound();
            }
            var response = new PriceResponse
            {
                Id = price.Id,
                Name = price.Name
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public ActionResult<PriceCreate> Post(PriceCreate rub)
    {
        using (var db = new ApplicationContext())
        {
            var entity = new Price 
            { 
                Name = rub.Name, 
                Products = [] 
            };
            db.Prices.Add(entity);
            db.SaveChanges();
            return Ok();
        }
    }
}
