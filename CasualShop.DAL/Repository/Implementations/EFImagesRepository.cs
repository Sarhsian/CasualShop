using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFImagesRepository : IImagesRepository
    {
        private EFDBContext context;

        public EFImagesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteImages(Image image)
        {
            context.Images.Remove(image);
            context.SaveChanges();
        }

        public IEnumerable<Image> GetAllImages()
        {
            return context.Images.ToList();
        }

        public Image GetImageById(int imageID)
        {
            return context.Images.FirstOrDefault(x => x.Id == imageID);
        }

        public void SaveImages(Image image)
        {
            context.Entry(image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
