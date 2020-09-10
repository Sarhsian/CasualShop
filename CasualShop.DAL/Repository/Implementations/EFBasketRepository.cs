using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFBasketRepository : IBasketsRepository
    {
        private EFDBContext context;

        public EFBasketRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteBaskets(Basket basket)
        {
            context.Baskets.Remove(basket);
            context.SaveChanges();
        }

        public IEnumerable<Basket> GetAllBaskets()
        {
            return context.Baskets.ToList();
        }

        public Basket GetBasketById(int basketId)
        {
            return context.Baskets.FirstOrDefault(x => x.Id == basketId);
        }

        public void SaveBaskets(Basket basket)
        {
            //context.Entry(basket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.Add(basket);
            context.SaveChanges();
        }
    }
}
