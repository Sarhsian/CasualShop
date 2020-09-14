using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Entities;
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
        private ImageService _imageService;
        //private TagService _tagService;

        public ClothesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _brandService = new BrandService(dataManager);
            _imageService = new ImageService(dataManager);
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
            if (_clothes.Image == null)
            {
                return new ClothesDto()
                {
                    Id = _clothes.Id,
                    Name = _clothes.Name,
                    ClothesBrand = new BrandDto() { Id = _clothes.Brand.Id, Name = _clothes.Brand.Name },
                    Description = _clothes.Description,
                    Price = _clothes.Price,
                    Tag = new TagDto { Id = _clothes.Tag.Id, Name = _clothes.Tag.Name }
                };
            }
            else
            {
                return new ClothesDto()
                {
                    Id = _clothes.Id,
                    Name = _clothes.Name,
                    ClothesBrand = new BrandDto() { Id = _clothes.Brand.Id, Name = _clothes.Brand.Name },
                    Description = _clothes.Description,
                    Price = _clothes.Price,
                    Image = new ImageDto() { Id = _clothes.Image.Id, Title = _clothes.Image.Title, ImageName = _clothes.Image.ImageName },
                    Tag = new TagDto { Id = _clothes.Tag.Id, Name = _clothes.Tag.Name }
                };
            }
        }
        
        public ClothesEditDto GetClothesEditDto(int clothesId = 0)
        {
            if (clothesId != 0)
            {
                var _clothesDb = _dataManager.Clothes.GetClothesById(clothesId);
                var _clothesEditDto = new ClothesEditDto()
                {
                    Id = _clothesDb.Id,
                    ClothesBrand = new BrandEditDto
                    {
                        Id = _clothesDb.Brand.Id,
                        Name = _clothesDb.Brand.Name
                    },
                    Tag = new TagEditDto
                    {
                        Id = _clothesDb.Tag.Id,
                        Name = _clothesDb.Name
                    },
                    Description = _clothesDb.Description,
                    Image = new ImageDto
                    {
                        Id = _clothesDb.Image.Id,
                        Title = _clothesDb.Image.Title,
                        ImageName = _clothesDb.Image.ImageName
                    },
                    Name = _clothesDb.Name,
                    Price = _clothesDb.Price
                };
                return _clothesEditDto;
            }
            else { return new ClothesEditDto() { }; }
        }

        public ClothesDto SaveClothesEditDtoToDb(ClothesEditDto clothesEditDto)
        {
            Clothes _clothesDbModel;
            if (clothesEditDto.Id != 0)
            {
                _clothesDbModel = _dataManager.Clothes.GetClothesById(clothesEditDto.Id);
            }
            else
            {
                _clothesDbModel = new Clothes();
            }
            _clothesDbModel.Name = clothesEditDto.Name;
            _clothesDbModel.Price = clothesEditDto.Price;
            _clothesDbModel.Image = new Image
            {
                Id = _clothesDbModel.Image.Id,
                Title = _clothesDbModel.Image.Title,
                ImageName = _clothesDbModel.Image.ImageName
            };
            _clothesDbModel.Description = clothesEditDto.Description;
            _clothesDbModel.Brand = new Brand
            {
                Id = clothesEditDto.ClothesBrand.Id,
                Name = clothesEditDto.ClothesBrand.Name
            };
            _clothesDbModel.Tag = new Tag
            {
                Id = clothesEditDto.Tag.Id,
                Name = clothesEditDto.Tag.Name
            };

            _dataManager.Clothes.SaveClothes(_clothesDbModel);

            return GetClothesModelById(_clothesDbModel.Id);
        }

        public ClothesEditDto CreateClothesEditDto()
        {
            return new ClothesEditDto() { };
        }



    }
}
