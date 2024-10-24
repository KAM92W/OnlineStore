using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebAPI.Dto;

namespace WebAPI.Controllers;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<Brand>> Get(int id)
    {
        using (var db = new ApplicationContext())
        {
            Brand user = await db.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
    }

    [HttpPost]
    public void Post (BrandName brand)
    {
        using (var db = new ApplicationContext())
        {
            Brand entity = new Brand { Name = brand.Name, Products = [] };
            db.Brands.Add(entity);
            db.SaveChanges();
        }
    }
}
