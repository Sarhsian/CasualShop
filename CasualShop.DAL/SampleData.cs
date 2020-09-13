using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Clothes.Any())
            {
                //context.Tags.Add(new Entities.Tag() { Name = "Shoes" });
                //context.Tags.Add(new Entities.Tag() { Name = "Shirt" });
                //context.Tags.Add(new Entities.Tag() { Name = "Jeans" });
                //context.Tags.Add(new Entities.Tag() { Name = "Leather" });
                //context.Tags.Add(new Entities.Tag() { Name = "Soft" });
                //context.SaveChanges();

                //context.Brands.Add(new Entities.Brand() { Name = "Gucci" });
                //context.Brands.Add(new Entities.Brand() { Name = "Nike" });
                //context.Brands.Add(new Entities.Brand() { Name = "Adidas" });
                //context.Brands.Add(new Entities.Brand() { Name = "Prada" });
                //context.SaveChanges();

                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Original Nike Top 2020",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 2),
                    Description = "Red with white dno",
                    //Image
                    Price = 300,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 1)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Gucci flip flap",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 1),
                    Description = "Gucci flip flap nara nara nana",
                    //Image
                    Price = 1500,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 5)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.Clothes.Add(new Entities.Clothes()
                {
                    Name = "Red evil selection",
                    Brand = context.Brands.FirstOrDefault(b => b.Id == 3),
                    Description = "Something interesting that you would like",
                    //Image
                    Price = 499,
                    Tag = context.Tags.FirstOrDefault(t => t.Id == 3)
                });
                context.SaveChanges();

            }

        }
    }
}
