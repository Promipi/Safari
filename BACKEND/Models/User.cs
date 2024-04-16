using Microsoft.AspNetCore.Identity;

namespace BACKEND.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Job { get; set; } //ocupacion

        public string Image { get; set; }
    }
}
