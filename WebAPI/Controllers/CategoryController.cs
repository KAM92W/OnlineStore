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

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        using (var db = new ApplicationContext())
        {
            var category = db.Categories.Find(id);
            var response = new CategoryResponse 
            { 
                Id = category.Id,
                Name = category.Name
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public void Post(CategoryCreate categoryname) 
    {
        using (var db = new ApplicationContext()) 
        {
            var entity = new Category { Name = categoryname.Name, Products = [] };
            db.Categories.Add(entity);
            db.SaveChanges();
        }
    }
}
