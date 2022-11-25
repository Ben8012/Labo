using BLL.Models.DTO.Account;
using BLL.Models.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountBll
    {
        List<AccountBll> GetAll();
        AccountBll GetById(int id);

        AccountBll Insert(AddAccountFormBll addAccountFormBll);

        AccountBll Update(UpdateAccountFormBll updateAccountFormBll);

        int Delete(int id);

        int Desactivate(int id);

        int Reactivate(int id);
    }
}
