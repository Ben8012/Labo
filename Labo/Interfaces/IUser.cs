using Labo.Models.DTO.UserAPI;
using Labo.Models.Forms.User;

namespace Labo.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        User? Insert(AddUserForm form);

        User? Update(UpdateUserForm form);

        int? Delete(int id);

        User Login(LoginForm form);
    }
}
