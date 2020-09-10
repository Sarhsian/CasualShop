using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string CurrentUser { get; set; }
        public int ClothesId { get; set; }
        public int Count { get; set; }
        public bool isProcessed { get; set; }
    }

    public class BasketEditDto
    {
        public int Id { get; set; }
        public string CurrentUser { get; set; }
        public int ClothesId { get; set; }
        public int Count { get; set; }
        public bool isProcessed { get; set; }
    }
}
