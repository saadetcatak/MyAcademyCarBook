using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DtoLayer.CarCategoryDto;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void TDelete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> TGetAllCarsWithBrands()
        {
            return _carDal.GetAllCarsWithBrands();
        }

        public Car TGetByID(int id)
        {
           return _carDal.GetByID(id);
        }

        public List<CarCategoryDto> TGetCategoryCount()
        {
           return _carDal.GetCategoryCount();
        }

        public List<Car> TGetLast5Cars()
        {
            return _carDal.GetLast5Cars();
        }

        public List<Car> TGetListAll()
        {
            return _carDal.GetListAll();
        }

        public void TInsert(Car entity)
        {
            _carDal.Insert(entity);
        }

        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
