using DataBase.Models;
using DataBase;
using WebAPI.InterfacesAndRepositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.InterfacesAndRepositories.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public IEnumerable<Brand> ReadAll()
        {
            using (var db = new ApplicationContext())
            {
                return db.Brands.ToList();
            }
        }

        public Brand Read(int id)
        {
            using (var db = new ApplicationContext())
            {
                var brand = db.Brands
                    .FirstOrDefault(x => x.Id == id);
                return brand;
            }
        }

        public void Create(Brand brand)
        {
            using (var db = new ApplicationContext())
            {
                db.Brands.Add(brand);
                db.SaveChanges();
            }
        }
    }
}