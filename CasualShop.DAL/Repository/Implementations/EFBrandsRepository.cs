using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFBrandsRepository : IBrandsRepository
    {
        private EFDBContext context;

        public EFBrandsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteBrands(Brand brand)
        {
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return context.Brands.ToList();
        }

        public Brand GetBrandById(int brandId)
        {
            return context.Brands.FirstOrDefault(x => x.Id == brandId);
        }

        public void SaveBrands(Brand brands)
        {
            context.Entry(brands).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
