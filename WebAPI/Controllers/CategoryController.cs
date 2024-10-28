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
    public ActionResult <CategoryResponse> GetCategory(int id)
    {
        using (var db = new ApplicationContext())
        {
            var category = db.Categories
                .FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            var response = new CategoryResponse 
            { 
                Id = category.Id,
                Name = category.Name
            };
            return Ok(response);
        }
    }

    [HttpPost]
    public ActionResult <CategoryCreate> Post (CategoryCreate categoryname) 
    {
        using (var db = new ApplicationContext()) 
        {
            var entity = new Category 
            { 
                Name = categoryname.Name, 
                Products = [] 
            };
            db.Categories.Add(entity);
            db.SaveChanges();
            return Ok();
        }
    }
}
