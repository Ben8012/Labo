using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO.Account;
using BLL.Models.Forms.Account;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountBllService : IAccountBll
    {
        private readonly IAccountDal _accountDal;

        public AccountBllService(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public int Desactivate(int id)
        {
            throw new NotImplementedException();
        }

        public List<AccountBll> GetAll()
        {
            return _accountDal.GetAll().Select(a => a.ToAccountBll()).ToList();
        }

        public AccountBll Insert(AddAccountFormBll addAccountFormBll)
        {
            return _accountDal.Insert(addAccountFormBll.ToaddAccountFormDal()).ToAccountBll();
        }

        public AccountBll Update(UpdateAccountFormBll updateAccountFormBll)
        {
            throw new NotImplementedException();
        }
    }
}
