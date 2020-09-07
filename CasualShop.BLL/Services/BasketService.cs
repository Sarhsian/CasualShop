using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class BasketService
    {
        private DataManager _dataManager;

        public BasketService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<BasketDto> GetBasketsList()
        {
            var _baskets = _dataManager.Baskets.GetAllBaskets();
            List<BasketDto> _modelsList = new List<BasketDto>();
            foreach (var item in _baskets)
            {
                _modelsList.Add(BasketDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public BasketDto BasketDBToViewModelById(int basketId)
        {
            var _baskets = _dataManager.Baskets.GetBasketById(basketId);

            return new BasketDto()
            {
                Id = _baskets.Id,
                CurrentUser = _baskets.CurrentUser,
                BasketClothes = new ClothesDto 
                {
                    Id = _baskets.BasketClothes.Id, 
                    Name = _baskets.BasketClothes.Name,
                    Description = _baskets.BasketClothes.Description,
                    ClothesBrand = new BrandDto 
                    { 
                        Id = _baskets.BasketClothes.ClothesBrand.Id,
                        Name = _baskets.BasketClothes.ClothesBrand.Name
                    },
                    Tag = new TagDto
                    {
                        Id = _baskets.BasketClothes.Tag.Id,
                        Name = _baskets.BasketClothes.Tag.Name
                    },
                    //Image =
                    Price = _baskets.BasketClothes.Price
                },
                
            };
        }
    }
}
