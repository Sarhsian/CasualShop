using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository
{
    public class DataManager
    {
        private readonly IClothesRepository _clothesRepository;
        private readonly IBrandsRepository _brandsRepository;
        private ITagsRepository _tagsRepository;

        public DataManager(IClothesRepository clothesRepository, ITagsRepository tagsRepository, IBrandsRepository brandsRepository)
        {
            _clothesRepository = clothesRepository;
            _brandsRepository = brandsRepository;
            _tagsRepository = tagsRepository;
        }

        public IClothesRepository Clothes { get { return _clothesRepository; } }
        public IBrandsRepository Brands { get { return _brandsRepository; } }
        public ITagsRepository Tags { get { return _tagsRepository; } }


    }
}
