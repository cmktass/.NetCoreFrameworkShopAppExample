using Microsoft.AspNetCore.Identity;

namespace shopapp.ui.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    
    }
}