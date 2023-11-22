using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
    public class Car
    {
        public int CarID { get; set; }
        public string Model { get; set; }
        public int CarCategoryID { get; set; }
        public CarCategory CarCategory { get; set; }
        public string CarName { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public string ImageUrl { get; set; }
        public string GeatType { get; set; }
        public string GasType { get; set; }
        public int Km { get; set; }
        public byte PersonCount { get; set; }
        public int Year { get; set; }
        public bool Status { get; set; }
        public decimal RentPrice { get; set; }
        public int CarStatusID { get; set; }
        public CarStatus CarStatus { get; set; }
        public List<Price> Prices { get; set; }
        public List<CarDetail> CarDetails { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
