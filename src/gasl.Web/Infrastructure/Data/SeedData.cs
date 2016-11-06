using System;
using System.Linq;
using System.Threading.Tasks;
using gasl.Web.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace gasl.Web.Infrastructure.Data
{
    public class SeedData
    {
        private readonly UserContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationRoot _configuration;

        public SeedData(UserContext ctx,
            UserManager<User> userManager,
            IConfigurationRoot configuration)
        {
            _ctx = ctx;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task InitializeAsync()
        {
            if (true)
            {
                await CreateAdminAsync();
            }
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

        private bool NoUsersExist()
        {
            return !_ctx.Users?.Any() ?? true;
        }

    }
}