using DAL.Models.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransactionDal
    {
        IEnumerable<AllInfoCreditUserDal> GetAllInfoCreditByUser(int Id);
    }
}
