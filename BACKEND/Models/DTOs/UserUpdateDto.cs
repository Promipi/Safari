using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Models.DTOs
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Job { get; set; } //ocupacion

        public string Image { get; set; }

    }
}
