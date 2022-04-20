using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: /User
        [HttpGet("{userID}")]
        public IActionResult GetUserOrders(int userID)
        {
            CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext();
            List<RentalOrderDetail> userOrdersList = DBInteraction.RentalOrderDetails.Where(order => order.UserId == userID).ToList();
            if (userOrdersList.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(userOrdersList);
            }
        }

        // POST /User/PostNewOrder
        [HttpPost("[action]")]
        public IActionResult PostNewOrder([FromBody] RentalOrderDetail newOrder)
        {
            CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext();
            DBInteraction.RentalOrderDetails.Add(newOrder);
            DBInteraction.SaveChanges();
            //Not sure what to return yet
            return Created("undecided", newOrder);
        }
    }
}
