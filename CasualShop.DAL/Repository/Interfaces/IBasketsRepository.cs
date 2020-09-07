using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IBasketsRepository
    {
        IEnumerable<Basket> GetAllBaskets();
        Basket GetBasketById(int basketId);
        void SaveBaskets(Basket basket);
        void DeleteBaskets(Basket basket);
    }
}
