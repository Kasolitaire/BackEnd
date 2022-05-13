using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        // POST /SignUp/PostNewUser
        [HttpPost("[action]")]
        public IActionResult PostNewUser([FromBody] User newUser)
        {
            using (CarRentalDatabaseContext databaseInteraction = new CarRentalDatabaseContext()) 
            {
                if (null != databaseInteraction.Users.FirstOrDefault(row => row.Username == newUser.Username || row.Email == newUser.Email))
                {
                    return NotFound("User with same email or user-name already exists");
                }
                else
                {
                    newUser.UserRole = "standard";
                    databaseInteraction.Users.Add(newUser);
                    databaseInteraction.SaveChanges();
                    return Created("User was created", newUser);
                }
            }
        }
    }
}
