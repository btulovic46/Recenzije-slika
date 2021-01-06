using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Grade { get; set; }
        public int ReviewerId { get; set; }
        public int PictureId { get; set; }
    }
}
