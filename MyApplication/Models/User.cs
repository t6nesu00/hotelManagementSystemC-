using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class User
    {
        public string Login { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}