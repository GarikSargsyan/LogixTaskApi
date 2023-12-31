﻿using System.ComponentModel.DataAnnotations;

namespace LogixTaskApi.Models.RequestModels
{
    public class SignInRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
