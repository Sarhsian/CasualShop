using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IBrandsRepository
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
        void SaveBrands(Brand brand);
        void DeleteBrands(Brand brand);
    }
}
