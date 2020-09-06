using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class BrandDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
    }

    public class BrandEditDto
    {
        public int BrandId { get; set; }
    }
}
