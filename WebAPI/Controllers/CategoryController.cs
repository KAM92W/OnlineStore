using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Category> Get()
    {
        using (var db = new ApplicationContext())
        {
            return db.Categories.ToList();
        }
    }

    [HttpPost]
    public void Post(CategoryName categoryname) 
    {
        using (var db = new ApplicationContext()) 
        {
            var entity = new Category { Name = categoryname.Name, Products = [] };
            db.Categories.Add(entity);
            db.SaveChanges();
        }
    }
}
