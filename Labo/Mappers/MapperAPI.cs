using BLL.Models.DTO.Account;
using BLL.Models.DTO.Transaction;
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using BLL.Models.Forms.Account;
using Labo.Models.DTO.Transaction;
using Labo.Models.DTO.User;
using Labo.Models.Forms.Account;
using Labo.Models.Forms.User;
using System.Data.Common;

namespace Labo.Models.Mappers
{
    internal static class MapperAPI
    {
        internal static User ToUser(this UserBll userBll)
        {
            return new User()
            {
                Id = userBll.Id,
                FirstName = userBll.FirstName,
                LastName = userBll.LastName,
                Birthdate = userBll.Birthdate,
                Email = userBll.Email,
                CreatedAt = userBll.CreatedAt,
                UpdatedAt = userBll.UpdatedAt,
            };
        }


        internal static Account ToAccount(this AccountBll accountBll)
        {
            return new Account()
            {
                Id = accountBll.Id,
                Number = accountBll.Number,
                AccountType = accountBll.AccountType,
                ReceiverName = accountBll.ReceiverName,
                Communication = accountBll.Communication,
                IsOwner = accountBll.IsOwner,
                User = accountBll.User.ToUser()
            };
        }

       

        internal static AddUserFormBll ToAddUserFromBll(this AddUserForm addUserFrom)
        {
            return new AddUserFormBll()
            {

                FirstName = addUserFrom.FirstName,
                LastName = addUserFrom.LastName,
                Birthdate = addUserFrom.Birthdate,
                Email = addUserFrom.Email,
                Password = addUserFrom.Password
            };
        }


        internal static UpdateUserFormBll ToUpdateUserFormBll(this UpdateUserForm updateUserForm)
        {
            return new UpdateUserFormBll()
            {
                Id = updateUserForm.Id,
                FirstName = updateUserForm.FirstName,
                LastName = updateUserForm.LastName,
                Birthdate = updateUserForm.Birthdate,
                Email = updateUserForm.Email,
             
            };
        }

        internal static LoginFormBll ToLoginFormBll(this LoginForm loginForm)
        {
            return new LoginFormBll()
            {
                Email = loginForm.Email,
                Password = loginForm.Password
            };
        }


        internal static AddAccountFormBll ToAddAccountFromBll(this AddAccountForm accountForm)
        {
            return new AddAccountFormBll()
            {
                Number = accountForm.Number,
                AccountType = accountForm.AccountType,
                ReceiverName = accountForm.ReceiverName,
                Communication = accountForm.Communication,
                IsOwner = accountForm.IsOwner,
                UserId = accountForm.UserId,
            };
        }

        internal static AllInfoCreditUser ToGetAllInfoCreditByUserDal(this AllInfoCreditUserBll allInfoCreditByUserDal)
        {
            return new AllInfoCreditUser()
            {
                FirstName = allInfoCreditByUserDal.FirstName,
                LastName = allInfoCreditByUserDal.LastName,
                ExecutionDate = allInfoCreditByUserDal.ExecutionDate,
                BudgetLabel = allInfoCreditByUserDal.BudgetLabel,
                Communication = allInfoCreditByUserDal.Communication,
                BudgetPeriode = allInfoCreditByUserDal.BudgetPeriode,
                TotalAmount = allInfoCreditByUserDal.TotalAmount,
                Number = allInfoCreditByUserDal.Number,
                ReceiverName = allInfoCreditByUserDal.ReceiverName
            };
        }

        internal static UpdateAccountFormBll ToUpdateAccountFormBll(this UpdateAccountForm account)
        {
            return new UpdateAccountFormBll()
            {
                Id = account.Id,
                Number = account.Number,
                AccountType = account.AccountType,
                ReceiverName = account.ReceiverName,
                Communication = account.Communication,
                IsOwner = account.IsOwner,
                UserId = account.UserId,
            };
        }
    }
}

