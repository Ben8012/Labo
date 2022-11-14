using Labo.Models;
using Labo.Models.Forms;
using Labo.Models.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools;

namespace Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public TransactionController(ILogger<TransactionController> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        //[HttpGet("GetByAccountId/{id}")]
        //public IActionResult GetByAccountId(int id)
        //{
        //    Command command = new Command("SELECT Id, UserId,AccountId,CategorieId,Amout FROM [Transaction] WHERE AccountId=@Id;", false);
        //    command.AddParameter("Id", id);
        //    try
        //    {
        //        return Ok(_connection.ExecuteReader(command, dr => dr.ToTransaction()).ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return BadRequest(new { Message = "Un probleme est survenu lors de la recuperation des données, contactez l'admin" });
        //    }
        //}


        //[HttpPost("Insert")]
        //public IActionResult Insert(AddTransationForm form)
        //{
        //    Command command = new Command("INSERT INTO [Transaction](UserId, AccountId, CategorieId, Amout) OUTPUT inserted.id VALUES(@UserId, @AccountId, @CategorieId, @Amout); ", false);
        //    command.AddParameter("UserId", form.UserId);
        //    command.AddParameter("AccountId", form.AccountId);
        //    command.AddParameter("CategorieId", form.CategorieId);
        //    command.AddParameter("Amout", form.Amout);

        //    int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré

        //    if (id.HasValue)
        //    {
        //        Transaction transaction = new Transaction()
        //        {
        //            Id = id.Value,
        //            AccountId = form.AccountId,
        //            UserId = form.UserId,
        //            CategorieId = form.CategorieId,
        //            Amout = form.Amout,

        //        };
        //        return Ok(transaction);
        //    }
        //    else
        //    {
        //        return BadRequest(new { Message = "l'insertion de la transaction a échoué" });
        //    }
        //}



        //[HttpPut("Update")]
        //public IActionResult Update(UpdateTransactionForm form)
        //{
          
        //    Command command = new Command("UPDATE [Transaction] SET UserId=@UserId, AccountId=@AccountId, CategorieId=@CategorieId, Amout=@Amout OUTPUT inserted.id WHERE Id = @Id", false);
        //    command.AddParameter("Id", form.Id);
        //    command.AddParameter("UserId", form.UserId);
        //    command.AddParameter("AccountId", form.AccountId);
        //    command.AddParameter("CategorieId", form.CategorieId);
        //    command.AddParameter("Amout", form.Amout);

        //    int? resultid = (int?)_connection.ExecuteScalar(command);

        //    if (resultid.HasValue)
        //    {
        //        Transaction transaction = new Transaction()
        //        {
        //            Id = resultid.Value,
        //            UserId = form.UserId,
        //            AccountId = form.AccountId,
        //            CategorieId = form.CategorieId,
        //            Amout = form.Amout,

        //        };

        //        return Ok(transaction);
        //    }
        //    else
        //    {
        //        return BadRequest(new { Message = "l'insertion a échoué" });
        //    }
        //}

        //[HttpDelete("Delete/{id}")]
        //public IActionResult Delete(int id) 
        //{
        //    Command command = new Command("DELETE FROM [Transaction] WHERE Id=@Id",false);
        //    command.AddParameter("Id", id);
        //    try
        //    {
        //        return Ok(_connection.ExecuteNonQuery(command));
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(new { Message = "la suppression de la transaction a échoué" });
        //    }
        //}
    }
}
