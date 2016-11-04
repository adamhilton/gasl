using gasl.Web.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gasl.Web.Infrastructure.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext() {}
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}