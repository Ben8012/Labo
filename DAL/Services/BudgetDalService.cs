using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO.Budget;
using DAL.Models.Forms.Budget;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class BudgetDalService : IBudgetDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;
        private readonly MyTools _myTools;
        public BudgetDalService(ILogger<BudgetDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
            _myTools = new MyTools(connection);
        }

        public int Delete(int id)
        {
            int nbligne;
            Command command = new Command("DELETE FROM [Budget] WHERE Id = @Id", false);
            command.AddParameter("id", id);
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 1) return -1;
                return nbligne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Desactivate(int id)
        {
            Command command = new Command("UPDATE [Budget] SET IsActive = 0 WHERE @Id= Id", false);
            command.AddParameter("id", id);

            int nbligne;
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 1) return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nbligne;
        }

        public int Reactivate(int id)
        {
            Command command = new Command("UPDATE [Budget] SET IsActive = 1 WHERE @Id= Id", false);
            command.AddParameter("id", id);

            int nbligne;
            try
            {
                nbligne = _connection.ExecuteNonQuery(command);
                if (nbligne != 1) return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nbligne;
        }

        public IEnumerable<BudgetDal> GetAll()
        {
            Command command = new Command("SELECT * FROM Budget", false);
            try
            {
                IEnumerable<BudgetDal> budgets = _connection.ExecuteReader(command, dr => dr.ToBudgetDal());   
                if (budgets == null) throw new Exception(" il n'y pas de compte !");
                return budgets;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public BudgetDal Insert(AddBudgetFormDal addForm)
        {
            bool isUserIdOk = _myTools.IsForeignKeyValid("Budget", addForm.UserId);
            if (!isUserIdOk) throw new Exception("clée etrangere userId invalide");

            Command command = new Command("INSERT INTO [Budget](PeriodByMonth, Label, CreatedAt, UserId, IsActive ) OUTPUT inserted.id VALUES (@PeriodByMonth, @Label, GETDATE(), @UserId, 1)", false);
            command.AddParameter("PeriodByMonth", addForm.PediodByMonth);
            command.AddParameter("Label", addForm.Label);
            command.AddParameter("UserId", addForm.UserId);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command);
                if (!id.HasValue) throw new Exception("probleme ! l'insertion dans la db a echoué");
                BudgetDal? budget = GetById(id.Value);
                if (budget is null) throw new Exception("probleme ! ce compte n'existe pas");
                return budget;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public BudgetDal Update(UpdateBudgetFormDal updateBudgetFormDal)
        {
            bool isUserIdOk = _myTools.IsForeignKeyValid("Budget", updateBudgetFormDal.UserId);
            if (!isUserIdOk) throw new Exception("clée etrangere userId invalide");

            Command command = new Command("UPDATE [Budget] SET PeriodByMonth = @PeriodByMonth , Label = @Label , UserId = @UserId, UpdatedAt = GETDATE() OUTPUT inserted.id WHERE Id =@Id", false);
            command.AddParameter("PeriodByMonth", updateBudgetFormDal.PediodByMonth);
            command.AddParameter("Label", updateBudgetFormDal.Label);
            command.AddParameter("UserId", updateBudgetFormDal.UserId);
            command.AddParameter("Id", updateBudgetFormDal.Id);
          
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                BudgetDal? budget = GetById(resultid.Value);
                if (budget is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return budget;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public BudgetDal GetById(int id)
        {
            Command command = new Command("SELECT * FROM Budget WHERE Id = @Id  ", false);
            command.AddParameter("Id", id);
            try
            {
                BudgetDal? budget = _connection.ExecuteReader(command, dr => dr.ToBudgetDal()).SingleOrDefault();
                if (budget == null) throw new Exception(" Id invalide !");
                return budget;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
