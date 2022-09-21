using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeek02.Areas.Main.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}