using BLL.Models.DTO.Account;
using BLL.Models.DTO.Transaction;
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using BLL.Models.Forms.Account;
using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Transaction;
using DAL.Models.Forms;
using DAL.Models.Forms.Account;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    internal static class MapperBll
    {

        // vers la BLL
        internal static UserBll ToUserBll(this UserDal userBll)
        {
            return new UserBll()
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

        internal static AccountBll ToAccountBll(this AccountDal accountDal)
        {
            return new AccountBll()
            {
               Id = accountDal.Id,
               Number = accountDal.Number,
               AccountType = accountDal.AccountType,
               ReceiverName = accountDal.ReceiverName,
               Communication = accountDal.Communication,
               IsOwner = accountDal.IsOwner,    
               User = accountDal.User.ToUserBll()
            };
        }



        // vers la DAL

        internal static AddUserFormDal ToAddUserFromDal(this AddUserFormBll addUserFromBll)
        {
            return new AddUserFormDal()
            {
               
                FirstName = addUserFromBll.FirstName,
                LastName = addUserFromBll.LastName,
                Birthdate = addUserFromBll.Birthdate,
                Email = addUserFromBll.Email,
                Password = addUserFromBll.Password
            };
        }


        internal static UpdateUserFormDal ToUpdateUserFormDal(this UpdateUserFormBll addUserFromBll)
        {
            return new UpdateUserFormDal()
            {
                Id = addUserFromBll.Id,
                FirstName = addUserFromBll.FirstName,
                LastName = addUserFromBll.LastName,
                Birthdate = addUserFromBll.Birthdate,
                Email = addUserFromBll.Email
            };
        }


        internal static LoginFormDal ToLoginFormDal(this LoginFormBll loginFormBll)
        {
            return new LoginFormDal()
            {
                Email = loginFormBll.Email, 
                Password = loginFormBll.Password
            };
        }

        internal static AddAccountFormDal ToAddAccountFormDal(this AddAccountFormBll accountBll)
        {
            return new AddAccountFormDal()
            {
                Number = accountBll.Number,
                AccountType = accountBll.AccountType,
                ReceiverName = accountBll.ReceiverName,
                Communication = accountBll.Communication,
                IsOwner = accountBll.IsOwner,
                UserId = accountBll.UserId,
            };
        }


        internal static UpdateAccountFormDal ToUpdateAccountFormDal(this UpdateAccountFormBll accountBll)
        {
            return new UpdateAccountFormDal()
            {
                Id = accountBll.Id,
                Number = accountBll.Number,
                AccountType = accountBll.AccountType,
                ReceiverName = accountBll.ReceiverName,
                Communication = accountBll.Communication,
                IsOwner = accountBll.IsOwner,
                UserId = accountBll.UserId,
            };
        }

        internal static AllInfoCreditUserBll ToGetAllInfoCreditByUserDal(this AllInfoCreditUserDal allInfoCreditByUserDal)
        {
            return new AllInfoCreditUserBll()
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

    }
}


