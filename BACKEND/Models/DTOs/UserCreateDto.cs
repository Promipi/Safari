using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Models.DTOs
{
    public class UserCreateDto 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Job { get; set; } //ocupacion

        public string Image { get; set; }


    }
}
