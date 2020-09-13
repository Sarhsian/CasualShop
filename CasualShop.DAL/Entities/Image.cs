using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CasualShop.DAL.Entities
{
    [Table("Images_tbl")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }
        public ICollection<Clothes> Clotheses { get; set; }
        public Image()
        {
            Clotheses = new List<Clothes>();
        }
    }
}
