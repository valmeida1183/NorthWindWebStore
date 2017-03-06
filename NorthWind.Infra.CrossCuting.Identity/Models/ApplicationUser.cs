using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Infra.CrossCuting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }

        public ApplicationUser()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
