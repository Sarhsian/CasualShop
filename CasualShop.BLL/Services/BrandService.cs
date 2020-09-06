using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class BrandService
    {
        private DataManager _dataManager;
        public BrandService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<BrandDto> GetBrandsList()
        {
            var _brands = _dataManager.Brands.GetAllBrands();
            List<BrandDto> _modelsList = new List<BrandDto>();
            foreach (var item in _brands)
            {
                _modelsList.Add(BrandDBToViewModelById(item.Id));
            }
            return _modelsList;
        }


        public BrandDto BrandDBToViewModelById(int brandId)
        {
            var _brands = _dataManager.Brands.GetBrandById(brandId);

            return new BrandDto() {
                Id = _brands.Id,
                Name = _brands.Name
            };
        }

        






    }
}
