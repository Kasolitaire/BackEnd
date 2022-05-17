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
        // GET: /User/<int>
        [HttpGet("{userID}")]
        public IActionResult GetUserOrders(int userID)
        {
            using (CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext()) 
            {
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
        }

        // POST /User/PostNewOrder,<int>
        [HttpPost("[action],{vehicleID}")]
        public IActionResult PostNewOrder([FromBody] RentalOrderDetail newOrder, int vehicleID)
        {   
            using (CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext())
            {
                VehicleInventory matchingVehicle = DBInteraction.VehicleInventories.FirstOrDefault<VehicleInventory>(vehicle => vehicle.VehicleId == vehicleID);
                if (matchingVehicle.Available == true) 
                {
                    matchingVehicle.Available = false;
                    DBInteraction.RentalOrderDetails.Add(newOrder);
                    DBInteraction.SaveChanges();
                    //Not sure what to return yet
                    return Created("undecided", newOrder);
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
    }
}
