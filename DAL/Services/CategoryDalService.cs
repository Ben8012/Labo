using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO.Category;
using DAL.Models.Forms.Category;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class CategoryDalService : ICategoryDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public CategoryDalService(ILogger<CategoryDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }


        public int Delete(int id)
        {
            int nbligne;
            Command command = new Command("DELETE FROM [Category] WHERE Id = @Id", false);
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
            Command command = new Command("UPDATE [Category] SET IsActive = 0 WHERE @Id= Id", false);
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
            Command command = new Command("UPDATE [Category] SET IsActive = 1 WHERE @Id= Id", false);
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

        public IEnumerable<CategoryDal> GetAll()
        {
            Command command = new Command("SELECT * FROM Category", false);
            try
            {
                IEnumerable<CategoryDal> categorys = _connection.ExecuteReader(command, dr => dr.ToCategoryDal());
                if (categorys == null) throw new Exception(" il n'y pas de compte !");
                return categorys;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public CategoryDal Insert(AddCategoryFormDal addForm)
        {
            Command command = new Command("INSERT INTO [Category]( Label, CreatedAt, IsActive ) OUTPUT inserted.id VALUES ( @Label, GETDATE(), 1)", false);
            command.AddParameter("Label", addForm.Label);
         
            try
            {
                int? id = (int?)_connection.ExecuteScalar(command);
                if (!id.HasValue) throw new Exception("probleme ! l'insertion dans la db a echoué");
                CategoryDal? category = GetById(id.Value);
                if (category is null) throw new Exception("probleme ! ce compte n'existe pas");
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CategoryDal Update(UpdateCategoryFormDal updatecategoryFormDal)
        {
            Command command = new Command("UPDATE [Category] SET Label = @Label, UpdatedAt = GETDATE() OUTPUT inserted.id WHERE Id =@Id", false);
            command.AddParameter("Id", updatecategoryFormDal.Id);
            command.AddParameter("Label", updatecategoryFormDal.Label);
           
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                CategoryDal? category = GetById(resultid.Value);
                if (category is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return category;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CategoryDal GetById(int id)
        {
            Command command = new Command("SELECT * FROM Category WHERE Id = @Id  ", false);
            command.AddParameter("Id", id);
            try
            {
                CategoryDal? category = _connection.ExecuteReader(command, dr => dr.ToCategoryDal()).SingleOrDefault();
                if (category == null) throw new Exception(" Id invalide !");
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
