using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public void TDelete(Review entity)
        {
            _reviewDal.Delete(entity);
        }

        public Review TGetByID(int id)
        {
            return _reviewDal.GetByID(id);
        }

        public List<Review> TGetListAll()
        {
           return _reviewDal.GetListAll();
        }

        public void TInsert(Review entity)
        {
            _reviewDal.Insert(entity);
        }

        public void TUpdate(Review entity)
        {
            _reviewDal.Update(entity);
        }
    }
}
