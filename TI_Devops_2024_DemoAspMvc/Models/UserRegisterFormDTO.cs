﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TI_Devops_2024_DemoAspMvc.Models
{
    public class UserRegisterFormDTO
    {
        [DisplayName("Pseudo")]
        [Required]
        public string Username { get; set; } = null!;

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
