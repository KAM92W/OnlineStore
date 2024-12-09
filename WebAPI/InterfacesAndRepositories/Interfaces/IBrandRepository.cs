using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.InterfacesAndRepositories.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> Get();
        Brand GetBrand(int id);
    }
}
