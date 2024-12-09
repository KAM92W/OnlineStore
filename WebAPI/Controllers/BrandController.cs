using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using WebAPI.Dto;
using WebAPI.InterfacesAndRepositories.Interfaces;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    [HttpGet]

    //public IEnumerable<Brand> Get()
    //{
    //    using (var db = new ApplicationContext())
    //    {
    //        return db.Brands.ToList();
    //    }
    //}

    [HttpGet("{id}")]
    //public ActionResult <BrandResponse> GetBrand(int id)
    //{
    //    using (var db = new ApplicationContext())
    //    {
    //        var brand = db.Brands
    //            .FirstOrDefault(x => x.Id == id);
    //        if (brand == null)
    //        {
    //            return NotFound();
    //        }
    //        var response = new BrandResponse 
    //        {
    //            Id = brand.Id,
    //            Name = brand.Name
    //        };
    //        return Ok (response);
    //    }
    //}

    [HttpPost]
    public ActionResult <BrandCreate> Post (BrandCreate brand)
    {
        using (var db = new ApplicationContext())
        {   
            var entity = new Brand 
            { 
                Name = brand.Name, 
                Products = [] 
            };
            db.Brands.Add(entity);
            db.SaveChanges();
            return Ok ();
        }
    }
}
