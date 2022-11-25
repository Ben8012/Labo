using BLL.Models.DTO.Account;
using BLL.Models.DTO.Budget;
using BLL.Models.DTO.Category;
using BLL.Models.DTO.Transaction;
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using BLL.Models.Forms.Account;
using BLL.Models.Forms.Budget;
using BLL.Models.Forms.Category;
using BLL.Models.Forms.Transaction;
using DAL.Models;
using DAL.Models.DTO.Account;
using DAL.Models.DTO.Budget;
using DAL.Models.DTO.Category;
using DAL.Models.DTO.Transaction;
using DAL.Models.Forms;
using DAL.Models.Forms.Account;
using DAL.Models.Forms.Budget;
using DAL.Models.Forms.Category;
using DAL.Models.Forms.Transaction;
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
               //Communication = accountDal.Communication,
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
                //Communication = accountBll.Communication,
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
                //Communication = accountBll.Communication,
                IsOwner = accountBll.IsOwner,
                UserId = accountBll.UserId,
            };
        }

        internal static TransactionBll ToTransactionBll(this TransactionDal transactionDal)
        {
            return new TransactionBll()
            {
                Id = transactionDal.Id,
                TotalAmount = transactionDal.TotalAmount,
                ExecutionDate = transactionDal.ExecutionDate,
                CreatedAt = transactionDal.CreatedAt,
                UpdateAt = transactionDal.UpdateAt,
                IsActive = transactionDal.IsActive,
                BudgetId = transactionDal.BudgetId,
                AccountDebitId = transactionDal.AccountDebitId,
                AccountCreditId = transactionDal.AccountCreditId,
                Communication = transactionDal.Communication

            };
        }

        internal static AddTransactionFormDal ToAddTransactionFromDal(this AddTransactionFormBll addTransactionFromBll)
        {
            return new AddTransactionFormDal()
            {
                TotalAmount  = addTransactionFromBll.TotalAmount,
                ExecutionDate = addTransactionFromBll.ExecutionDate,
                BudgetId = addTransactionFromBll.BudgetId,
                AccountDebitId = addTransactionFromBll.AccountDebitId,
                AccountCreditId = addTransactionFromBll.AccountCreditId, 
                Communication = addTransactionFromBll.Communication  
            };
        }

        internal static UpdateTransactionFormDal ToUpdateTransactionFromDal(this UpdateTransactionFormBll updateTransactionFromBll)
        {
            return new UpdateTransactionFormDal()
            {
                Id = updateTransactionFromBll.Id,
                TotalAmount = updateTransactionFromBll.TotalAmount,
                ExecutionDate = updateTransactionFromBll.ExecutionDate,
                BudgetId = updateTransactionFromBll.BudgetId,
                AccountDebitId = updateTransactionFromBll.AccountDebitId,
                AccountCreditId = updateTransactionFromBll.AccountCreditId,
                Communication = updateTransactionFromBll.Communication
            };
        }



        internal static CategoryBll ToCategoryBll(this CategoryDal categoryDal)
        {
            return new CategoryBll()
            {
                Id = categoryDal.Id,
                Label = categoryDal.Label, 
                CreatedAt = categoryDal.CreatedAt, 
                UpdatedAt = categoryDal.UpdatedAt, 
                IsActive = categoryDal.IsActive 
            };
        }


        internal static AddCategoryFormDal ToAddCategoryFromDal(this AddCategoryFormBll addCategoryFromBll)
        {
            return new AddCategoryFormDal()
            {
                Label = addCategoryFromBll.Label,
            };
        }

        internal static UpdateCategoryFormDal ToUpdateCategoryFromDal(this UpdateCategoryFormBll updateCategoryFromBll)
        {
            return new UpdateCategoryFormDal()
            {
                Id = updateCategoryFromBll.Id,
                Label = updateCategoryFromBll.Label,
            };
        }



        internal static BudgetBll ToBudgetBll(this BudgetDal budgetDal)
        {
            return new BudgetBll()
            {
                Id = budgetDal.Id,
                PediodByMonth = budgetDal.PediodByMonth,
                Label = budgetDal.Label, 
                UdpatedAt = budgetDal.UdpatedAt, 
                CreatedAt = budgetDal.CreatedAt,
                UserId = budgetDal.UserId 
            };
        }

        internal static AddBudgetFormDal ToAddBudgetFromDal(this AddBudgetFormBll addBudgetFromBll)
        {
            return new AddBudgetFormDal()
            {
                PediodByMonth = addBudgetFromBll.PediodByMonth,
                Label = addBudgetFromBll.Label,
                UserId = addBudgetFromBll.UserId
            };
        }

        internal static UpdateBudgetFormDal ToUpdateBudgetFromDal(this UpdateBudgetFormBll updateBudgetFromBll)
        {
            return new UpdateBudgetFormDal()
            {
                Id = updateBudgetFromBll.Id,
                PediodByMonth = updateBudgetFromBll.PediodByMonth,
                Label = updateBudgetFromBll.Label,
                UserId = updateBudgetFromBll.UserId
            };
        }

    }
}


