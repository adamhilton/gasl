using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using gasl.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gasl.Web.Domain
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext() {}
        public UserContext(DbContextOptions<gaslUserContext> options)
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