﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WPP.Model.General
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [StringLength(80, ErrorMessage = "email can't be more than 80 digits long")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(50, ErrorMessage = "email can't be more than 50 digits long")]
        public String Password { get; set; }
    }
}
