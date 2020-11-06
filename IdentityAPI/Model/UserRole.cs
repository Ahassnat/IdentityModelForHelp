using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Model
{
    public class UserRole: IdentityUserRole<int>
    {
        public User User { get; set; }  
        public Role Role { get; set; }
    }
}