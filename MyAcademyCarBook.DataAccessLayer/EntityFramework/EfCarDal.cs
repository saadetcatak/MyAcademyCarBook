using Microsoft.EntityFrameworkCore;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.DtoLayer.CarCategoryDto;
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

        public List<CarCategoryDto> GetCategoryCount()
        {
            var context = new CarBookContext();
            var categories = context.CarsCategories.Select(x => new CarCategoryDto
            {
                CategoryName = x.CategoryName,
                Count = context.Cars.Count(y => y.CarCategoryID == x.CarCategoryID)
            }).ToList();

            return categories;
        }

        public List<Car> GetLast5Cars()
        {
            var context=new CarBookContext();
            var values=context.Cars.OrderByDescending(x=>x.CarID).Take(5).ToList(); 
            return values;
        }

       
    }
}
