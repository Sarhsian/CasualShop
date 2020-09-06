using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFClothesRepository : IClothesRepository
    {
        private EFDBContext context;

        public EFClothesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Clothes> GetAllClothes()
        {
            return context.Set<Clothes>().Include(x => x.ClothesBrand).Include(x => x.Tag).ToList();
        }

        public Clothes GetClothesById(int clothesId)
        {
            return context.Set<Clothes>().Include(x => x.ClothesBrand).Include(x => x.Tag).FirstOrDefault(x => x.Id == clothesId);
        }

        public void SaveClothes(Clothes clothes)
        {
            context.Entry(clothes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteClothes(Clothes clothes)
        {
            context.Clothes.Remove(clothes);
            context.SaveChanges();
        }



    }
}
