using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IClothesRepository
    {
        IEnumerable<Clothes> GetAllClothes();
        Clothes GetClothesById(int clothesId);
        void SaveClothes(Clothes clothes);
        void DeleteClothes(Clothes clothes);
    }
}
