using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasualShop.DAL.Entities
{
    [Table("Clothes_tbl")]
    public class Clothes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public Brand ClothesBrand { get; set; }
        public Tag Tag { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
