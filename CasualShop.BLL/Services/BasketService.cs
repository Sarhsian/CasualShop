using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Entities;
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
                ClothesId = _baskets.BasketClothesId,
                isProcessed = _baskets.isProcessed
            };
        }

        public BasketEditDto GetBasketEditDto(int basketId = 0)
        {
            if (basketId != 0)
            {
                var _basketDB = _dataManager.Baskets.GetBasketById(basketId);
                var _basketEditDto = new BasketEditDto()
                {
                    //Id = _basketDB.Id,
                    CurrentUser = _basketDB.CurrentUser,
                    ClothesId = _basketDB.BasketClothesId,
                    Count = _basketDB.Count,
                    isProcessed = _basketDB.isProcessed
                };
                return _basketEditDto;
            }
            else { return new BasketEditDto() { }; }
        }

        public BasketDto SaveBasketEditDtoToDb(BasketEditDto basketEditDto)
        {
            Basket _basketDbModel;
            if (basketEditDto.Id != 0)
            {
                _basketDbModel = _dataManager.Baskets.GetBasketById(basketEditDto.Id);
            }
            else
            {
                _basketDbModel = new Basket();
            }
            _basketDbModel.CurrentUser = basketEditDto.CurrentUser;
            _basketDbModel.Count = basketEditDto.Count;
            _basketDbModel.isProcessed = basketEditDto.isProcessed;
            _basketDbModel.BasketClothesId = basketEditDto.ClothesId;

            _dataManager.Baskets.SaveBaskets(_basketDbModel);

            return BasketDBToViewModelById(_basketDbModel.Id);
        }

        public void UpdateBasketsDtoToDb(BasketDto basketEditDto)
        {
            Basket _basketDbModel;
            _basketDbModel = _dataManager.Baskets.GetBasketById(basketEditDto.Id);

            _basketDbModel.CurrentUser = basketEditDto.CurrentUser;
            _basketDbModel.Count = basketEditDto.Count;
            _basketDbModel.isProcessed = basketEditDto.isProcessed;
            _basketDbModel.BasketClothesId = basketEditDto.ClothesId;

            _dataManager.Baskets.UpdateBaskets(_basketDbModel);
        }

        public void DeleteBasketById(int basketId)
        {
            Basket _basketDbModel;            
            _basketDbModel = _dataManager.Baskets.GetBasketById(basketId);
            _dataManager.Baskets.DeleteBaskets(_basketDbModel);
        }

        public BasketEditDto CreateBasketEditDto()
        {
            return new BasketEditDto() {};
        }

    }
}
