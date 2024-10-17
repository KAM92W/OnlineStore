﻿using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Products.ToList();
            }
        }

        [HttpPost]
        public void Post(PictureLink link)
        {
            using (var db = new ApplicationContext())
            {
                var entity = new Product { Picture = link.Link };
                db.Products.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
