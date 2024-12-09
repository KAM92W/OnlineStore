using DataBase.Models;
using DataBase;
using WebAPI.InterfacesAndRepositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.InterfacesAndRepositories.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public IEnumerable<Brand> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Brands.ToList();
            }
        }

        public Brand GetBrand(int id)
        {
            using (var db = new ApplicationContext())
            {
                var brand = db.Brands
                    .FirstOrDefault(x => x.Id == id);

                var response = new BrandResponse
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
                к
            }
        }
    }
}
