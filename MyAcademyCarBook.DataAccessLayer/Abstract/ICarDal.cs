using MyAcademyCarBook.DtoLayer.CarCategoryDto;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.Abstract
{
   public interface ICarDal:IGenericDal<Car>
    {
        List<Car> GetAllCarsWithBrands();
        List<Car> GetLast5Cars();
        public List<CarCategoryDto> GetCategoryCount();

    }
}
