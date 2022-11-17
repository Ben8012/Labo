using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.Forms.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountDal
    {
        // Gérer les comptes :  Dont nous pourrons afficher la liste, créer, éditer et désactiver :
        List<AccountDal> GetAll();

        AccountDal Insert(AddAccountFormDal addAccountFormDal);

        AccountDal Update(UpdateAccountFormDal updateAccountFormDal);

        int Delete(int id);

        int Desactivate(int id);

        int Reactivate(int id);
    }
}
