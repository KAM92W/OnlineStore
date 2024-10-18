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
        public void Post (ProductName product)
        {
            using (var db = new ApplicationContext())
            {
                var entity = new Product 
                {
                    Picture = product.PictureLink,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    ModelId = product.ModelId,
                    PriceId = product.PriceId,
                    Properties = []
                };
                db.Products.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
