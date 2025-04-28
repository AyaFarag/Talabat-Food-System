using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Talabat.Infrastructure.Models;

namespace Talabat.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser , IdentityRole ,string >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
    }
}
