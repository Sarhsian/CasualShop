using CasualShop.BLL.Services;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL
{
    public class ServicesManager
    {
        DataManager _dataManager;
        //private ClothesService _clothesService;
        //private TagService _tagService;
        private BrandService _brandService;
        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _brandService = new BrandService(_dataManager);
        }
        public BrandService Brands { get { return _brandService; } }
    }
}
