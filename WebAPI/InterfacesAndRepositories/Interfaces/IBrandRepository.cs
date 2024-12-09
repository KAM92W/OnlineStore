using DataBase.Models;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.InterfacesAndRepositories.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> ReadAll();
        Brand Read(int id);
        void Create (BrandCreate brand);
    }
}