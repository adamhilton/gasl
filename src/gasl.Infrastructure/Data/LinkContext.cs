using Microsoft.EntityFrameworkCore;
using gasl.Domain.Entities;

namespace gasl.Infrastructure.Data
{
    public class LinkContext : DbContext
    {
        public LinkContext(DbContextOptions<LinkContext> options)
            : base(options)
        { }

        public DbSet<Link> Links { get; set; }
    }
}