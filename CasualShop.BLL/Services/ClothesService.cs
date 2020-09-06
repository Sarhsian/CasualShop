using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class ClothesService
    {
        private DataManager _dataManager;
        private BrandService _brandService;
        //private TagService _tagService;

        public ClothesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _brandService = new BrandService(dataManager);
        }

        public List<ClothesDto> GetClothesList()
        {
            var _clothes = _dataManager.Clothes.GetAllClothes();
            List<ClothesDto> _modelList = new List<ClothesDto>();

            foreach (var item in _clothes)
            {
                _modelList.Add(GetClothesModelById(item.Id));
            }
            return _modelList;
        }

        public ClothesDto GetClothesModelById(int clothesId)
        {
            var _clothes = _dataManager.Clothes.GetClothesById(clothesId);

            return new ClothesDto()
            {
                Id = _clothes.Id,
                Name = _clothes.Name,
                ClothesBrand = new BrandDto() { Id = _clothes.ClothesBrand.Id, Name = _clothes.ClothesBrand.Name },
                Description = _clothes.Description,
                Price = _clothes.Price,
                Image = _clothes.Image,
                Tag = new TagDto { Id = _clothes.Tag.Id, Name = _clothes.Tag.Name }
            };
        }


    }
}
