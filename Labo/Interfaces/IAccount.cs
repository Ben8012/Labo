using Labo.Models.DTO.AccountAPI;
using Labo.Models.Forms.Account;

namespace Labo.Interfaces
{
    public interface IAccount
    {
        List<Account> GetAll();

        Account Insert(AddAccountForm addAccountFormBll);

        Account Update(UpdateAccountForm updateAccountFormBll);

        int Delete(int id);

        int Desactivate(int id);

        int Reactivate(int id);
    }
}
