using ITAcademyEdu.Application.Abstractions;
using ITAcademyEdu.Infrastructure.Abstractions;
using ITAcademyEdu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ITAcademyEdu.Infrastructure.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IHashProvider _hashProvider;

        public AuthService(ApplicationDbContext dbContext, ITokenService tokenService, IHashProvider hashProvider)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _hashProvider = hashProvider;
        }

        public async Task<string> LoginAsync(string username, string password)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                throw new Exception("User not found");
            }


            if (user.PasswordHash != _hashProvider.GetHash(password))
            {
                throw new Exception("Password is wrong");
            }

            return _tokenService.GenerateAccessToken(user);
        }
    }
}
