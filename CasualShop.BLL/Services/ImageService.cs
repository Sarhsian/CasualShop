using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class ImageService
    {
        private DataManager _dataManager;
        public ImageService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }        

        public List<ImageDto> GetImagesList()
        {
            var _images = _dataManager.Images.GetAllImages();
            List<ImageDto> _modelsList = new List<ImageDto>();
            foreach (var item in _images)
            {
                _modelsList.Add(ImageDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public ImageDto ImageDBToViewModelById(int imageId)
        {
            var _images = _dataManager.Images.GetImageById(imageId);

            return new ImageDto()
            {
                Id = _images.Id,
                Title = _images.Title,
                ImageName = _images.ImageName
            };
        }
    }
}
