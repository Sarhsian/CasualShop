using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public string Title { get; set; }
        
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; } 

        public ICollection<Clothes> Clotheses { get; set; }
        public Image()
        {
            Clotheses = new List<Clothes>();
        }
    }
}
