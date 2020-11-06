using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Model
{
    public class User: IdentityUser<int>
    {
       public string ImgUrl { get; set; }
       public string Magior { get; set; }
       public string  Address { get; set; } 
       public ICollection<UserRole> UserRoles { get; set; }
                                   
    }

    }
    