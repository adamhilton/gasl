using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gasl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gasl.Infrastructure.Data
{
    public class LinkRepository
    {
        protected readonly DbSet<Link> _dbSet;
        protected readonly LinkContext _dbContext;

        public LinkRepository(LinkContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Links;
        }

        public Link Add(Link entity)
        {
            entity.Id = generateLinkId();

            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        private static Random random = new Random();

        private const int LinkIdLength = 7;

        private string generateLinkId() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, LinkIdLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Delete(Link entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Link GetById(string id)
        {
            return _dbSet.FirstOrDefault(i => i.Id == id);
        }

        public List<Link> List()
        {
            return _dbSet.ToList();
        }

        public async Task<List<Link>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Update(Link entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}