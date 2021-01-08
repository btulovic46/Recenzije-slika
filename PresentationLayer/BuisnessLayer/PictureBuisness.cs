using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class PictureBuisness
    {
        private readonly PictureRepository pictureRepository;

        public PictureBuisness()
        {
            this.pictureRepository = new PictureRepository();
        }
        public List<Picture> GetAllPictures()
        {
            return this.pictureRepository.GetAllPictures();
        }

        public bool InsertPicture(Picture p)
        {
            if (this.pictureRepository.InsertPicture(p) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
