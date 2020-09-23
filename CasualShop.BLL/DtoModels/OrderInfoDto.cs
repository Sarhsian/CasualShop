using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CasualShop.BLL.DtoModels
{
    public class OrderInfoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone is required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNum { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }
    }
}
