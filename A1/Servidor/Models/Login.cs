﻿using System.ComponentModel.DataAnnotations;

namespace Servidor.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username required.", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}