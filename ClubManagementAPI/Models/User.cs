using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Models
{
    public class User : IdentityUser<int>
    {
        //public int Id { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        
    }
}
