using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        // GET Admin>/<TableYouWant>
        [HttpGet("{requestedTable}")]
        public IActionResult GetRequestedTable(string requestedTable)
        {
            requestedTable = requestedTable.ToUpper();
            CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext();
            // Maybe add NoContent if the table is empty
            switch (requestedTable)
            {
                case "USERS":
                    return Ok(dbInteraction.Users);
                case "RENTALORDERDETAILS":
                    return Ok(dbInteraction.RentalOrderDetails);
                case "VEHICLETYPE":
                    return Ok(dbInteraction.VehicleTypes);
                case "VEHICLEINVENTORY":
                    return Ok(dbInteraction.VehicleInventories);
                default:
                    return BadRequest();
            }
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        ///Admin/UpdateUser/<UserID>
        [HttpPut("[action]/{UserID}")]
        public IActionResult UpdateUser(int UserID, [FromBody] User updatedUser)
        {
            //context.Entry(temp).CurrentValues.SetValues(order);
            //context.SaveChanges();
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                User originalUser = dbInteraction.Users.FirstOrDefault(user => user.UserId == UserID);
                if (originalUser != null) 
                {
                    updatedUser.UserId = originalUser.UserId;
                    dbInteraction.Entry(originalUser).CurrentValues.SetValues(updatedUser);
                    dbInteraction.SaveChanges();
                    return Ok(updatedUser);
                }
                else
                {
                    return NoContent();
                }
            }
        }




        // DELETE api/<AdminController>/5
        [HttpDelete("{id}", Name = "bob")]
        public void Delete(int id)
        {
        }
    }
}
