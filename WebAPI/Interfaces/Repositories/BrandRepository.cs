using DataBase.Models;
using DataBase;

namespace WebAPI.Interfaces.Repositories
{
    public class BrandRepository: IBrandRepository
    {
        public IEnumerable<Brand> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Brands.ToList();
            }
        }
    }
}
