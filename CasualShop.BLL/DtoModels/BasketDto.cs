using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string CurrentUser { get; set; }
        public ClothesDto BasketClothes { get; set; }
        public int Count { get; set; }
    }
}
