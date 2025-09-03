using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace FormalRPG.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Character> Characters { get; set; } = [];
    }

}
