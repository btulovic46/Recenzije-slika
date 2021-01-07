using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class GalleryBuisness
    {
        private readonly GalleryRepository galleryRepository;

        public GalleryBuisness()
        {
            this.galleryRepository = new GalleryRepository();
        }
        public List<Gallery> GetAllGalleries()
        {
            return this.galleryRepository.GetAllGalleries();
        }

        public bool InsertGallery(Gallery g)
        {
            if (this.galleryRepository.InsertGallery(g) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
