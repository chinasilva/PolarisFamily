using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PolarisFamily.Web.Models.MyViewModels
{
    public class ApplicationUser: IdentityUser<string>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString("D");
        }
        public ApplicationUser(string userName)
        {
            base.UserName = userName;
        }
    }
}
