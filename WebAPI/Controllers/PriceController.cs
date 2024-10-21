using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
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
