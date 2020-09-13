using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IImagesRepository
    {
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int imageID);
        void SaveImages(Image image);
        void DeleteImages(Image image);
    }
}
