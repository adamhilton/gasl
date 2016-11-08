using System;
using System.Linq;
using System.Threading.Tasks;
using gasl.Web.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using gasl.Domain.Entities;
using gasl.Infrastructure.Data;

namespace gasl.Web.Infrastructure.Data
{
    public class SeedData
    {
        private readonly UserContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationRoot _configuration;
        private readonly LinkRepository _linkRepo;

        public SeedData(UserContext ctx,
            UserManager<User> userManager,
            IConfigurationRoot configuration,
            LinkRepository linkRepo)
        {
            _ctx = ctx;
            _userManager = userManager;
            _configuration = configuration;
            _linkRepo = linkRepo;
        }

        public async Task InitializeAsync()
        {
            if (NoUsersExist())
            {
                await CreateAdminAsync();
            }

            await CreateLinks();
        }

        private async Task CreateAdminAsync()
        {
            var userName = _configuration.GetValue<string>("GASL_ADMINUSER") ?? string.Empty;
            var password = _configuration.GetValue<string>("GASL_ADMINPASS") ?? string.Empty;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Seed admin username or password is not set. Please set in enivronment or configuration file.");
            }

            await CreateUserAsync(userName, password);
        }

        private async Task CreateUserAsync(string userName, string password)
        {
            await _userManager.CreateAsync(new User()
            {
                UserName = userName
            }, password);
            _ctx.SaveChanges();
        }

        private async Task CreateLinks() 
        {
            for (int i = 0; i < 5; i ++)
            {
                var link = new Link
                {
                    Url = "adamhilton.net"
                };
                _linkRepo.Add(link);
            }
        }

        private bool NoUsersExist()
        {
            return !_ctx.Users?.Any() ?? true;
        }

    }
}