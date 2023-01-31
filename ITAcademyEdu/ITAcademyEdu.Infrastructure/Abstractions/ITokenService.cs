using ITAcademyEdu.Domain.Entities;

namespace ITAcademyEdu.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
