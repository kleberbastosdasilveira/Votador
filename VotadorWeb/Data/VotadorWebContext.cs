using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VotadorWeb.ViewModels;

namespace VotadorWeb.Areas.Identity.Data
{
    public class VotadorWebContext : IdentityDbContext<ApplicationUser>
    {
        public VotadorWebContext(DbContextOptions<VotadorWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}