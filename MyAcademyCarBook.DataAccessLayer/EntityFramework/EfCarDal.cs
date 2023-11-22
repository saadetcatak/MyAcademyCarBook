using Microsoft.EntityFrameworkCore;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        public List<Car> GetAllCarsWithBrands()
        {
            var context=new CarBookContext();
            var values=context.Cars.Include(x => x.Brand).Include(y=>y.CarStatus).ToList();
            return values;
        }

        public IEnumerable<Car> GetCarByFilters(string Model, string GeatType, int Year, string BrandName)
        {
            var context = new CarBookContext();
            IQueryable<Car> query = context.Cars;

            if(Model!=null)
            {
                query=query.Where(x=>x.Model.ToLower().Contains(Model.ToLower()));
            }
            if (GeatType!= null)
            {
                query = query.Where(x => x.GeatType.Contains(GeatType));
            }
            if (Year != null)
            {
                query = query.Where(x => x.Year>=Year);
            }
            if (BrandName != null)
            {
                query = query.Where(x => x.Brand.BrandName.ToLower().Contains(BrandName.ToLower()));
            }

            return query.ToList();
        }
    }
}
