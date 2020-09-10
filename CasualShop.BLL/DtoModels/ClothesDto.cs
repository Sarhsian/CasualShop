using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class ClothesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public BrandDto ClothesBrand { get; set; }
        public TagDto Tag { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class ClothesEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public BrandEditDto ClothesBrand { get; set; }
        public TagEditDto Tag { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
