using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class TagDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        //public ICollection<ClothesDto> Clothes { get; set; }
    }

    public class TagEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
