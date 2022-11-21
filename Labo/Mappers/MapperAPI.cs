using BLL.Models.DTO.Account;
using BLL.Models.DTO.Budget;
using BLL.Models.DTO.Category;
using BLL.Models.DTO.Transaction;
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using BLL.Models.Forms.Account;
using Labo.Models.DTO.AccountAPI;
using Labo.Models.DTO.BudgetAPI;
using Labo.Models.DTO.CategoryAPI;
using Labo.Models.DTO.TransactionAPI;
using Labo.Models.DTO.UserAPI;
using Labo.Models.Forms.Account;
using Labo.Models.Forms.User;
using System.Data.Common;

namespace Labo.Mappers
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



        internal static TransactionBudgetAccountsCategory ToTransaction(this TransactionBudgetAccountsCategoryBll transactionBll)
        {
            return new TransactionBudgetAccountsCategory()
            {
                Id = transactionBll.Id,
                TotalAmount = transactionBll.TotalAmount,
                ExecutionDate = transactionBll.ExecutionDate,
                CreatedAt = transactionBll.CreatedAt,
                UpdateAt = transactionBll.UpdateAt,
                IsActive = transactionBll.IsActive,
                Budget = transactionBll.Budget.ToBudget(),
                AccountDebit = transactionBll.AccountDebit.ToAccount(),
                AccountCredit = transactionBll.AccountDebit.ToAccount(),
                Category = transactionBll.Category.ToCategory()
            };
        }

        internal static Category ToCategory(this CategoryBll categoryBll)
        {
            return new Category()
            {
                Id = categoryBll.Id,
                MaxAmount = categoryBll.MaxAmount,
                Label = categoryBll.Label,
                CreatedAt = categoryBll.CreatedAt,
                UpdatedAt = categoryBll.UpdatedAt,
                IsActive = categoryBll.IsActive
            };
        }


        internal static Budget ToBudget(this BudgetBll budgetBll)
        {
            return new Budget()
            {
                Id = budgetBll.Id,
                PediodByMonth = budgetBll.PediodByMonth,
                Label = budgetBll.Label,
                UdpateAt = budgetBll.UdpateAt,
                CreatedAt = budgetBll.CreatedAt,
                User = budgetBll.User.ToUser()
            };
        }

    }
}

