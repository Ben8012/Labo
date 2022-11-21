
using Labo.Models.DTO.UserAPI;

namespace labo.Tools
{
    public interface ITokenManager
    {
        string GenerateJWTUser(User client);
      
    }
}