using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET Login/id,password
        [HttpGet("{loginID},{password}")]
        public IActionResult GetUserInfo(string loginID, string password)
        {
            CarRentalDatabaseContext databaseInteraction = new CarRentalDatabaseContext();
            User userLoginConfirmation = databaseInteraction.Users.FirstOrDefault(row => (row.Username == loginID || row.Email == loginID) && row.Password == password);
            if (userLoginConfirmation != null)
            {
                return Ok(userLoginConfirmation);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
