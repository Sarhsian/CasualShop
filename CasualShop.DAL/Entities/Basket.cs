using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CasualShop.DAL.Entities
{
    [Table("Baskets_tbl")]
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public  string CurrentUser { get; set; }
        public Clothes BasketClothes { get; set; }
        public int Count { get; set; }       
    }
}
