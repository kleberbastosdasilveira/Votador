using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VotadorWeb.Areas.Identity.Data
{
    public class VotadorWebContext : IdentityDbContext<IdentityUser>
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