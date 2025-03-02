using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Entity;

namespace UserService.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor accepting DbContextOptions and passing it to the base constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
