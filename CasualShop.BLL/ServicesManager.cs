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
        private ClothesService _clothesService;
        private TagService _tagService;
        private BrandService _brandService;
        private BasketService _basketService;
        private ImageService _imageService;
        
        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _brandService = new BrandService(_dataManager);
            _tagService = new TagService(_dataManager);
            _clothesService = new ClothesService(_dataManager);
            _basketService = new BasketService(_dataManager);
            _imageService = new ImageService(_dataManager);
        }
        public BrandService Brands { get { return _brandService; } }
        public ClothesService Clothes { get { return _clothesService; } }
        public BasketService Baskets { get { return _basketService; } }
        public ImageService Images { get; set; }
        public TagService Tags { get { return _tagService; } }
    }
}
