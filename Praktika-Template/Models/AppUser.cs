using Microsoft.AspNetCore.Identity;

namespace Praktika_Template.Models
{
    public class AppUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
