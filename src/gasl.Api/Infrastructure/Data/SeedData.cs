using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using gasl.Domain.Entities;
using gasl.Infrastructure.Data;

namespace gasl.Web.Infrastructure.Data
{
    public class SeedData
    {
        private readonly LinkRepository _linkRepo;

        public SeedData(
            LinkRepository linkRepo)
        {
            _linkRepo = linkRepo;
        }

        public async Task InitializeAsync()
        {
            await CreateLinks();
        }

        private async Task CreateLinks() 
        {
            for (int i = 0; i < 5; i ++)
            {
                var link = new Link
                {
                    Url = "https://github.com/Felsig/gasl"
                };
                _linkRepo.Add(link);
            }
        }
    }
}