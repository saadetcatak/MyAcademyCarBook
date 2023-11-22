using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.EntityLayer.Concrete
{
   public class Review
    {
        public int ReviewID { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public DateTime CommentDate { get => DateTime.Now; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
