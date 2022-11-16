
using Labo.Models.DTO.User;

namespace labo.Tools
{
    public interface ITokenManager
    {
        string GenerateJWTUser(User client);
      
    }
}