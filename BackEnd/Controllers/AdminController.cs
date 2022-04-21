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

        [HttpPut("[action]/{OrderID}")]
        public IActionResult UpdateOrder(int OrderID, [FromBody] RentalOrderDetail updatedOrder)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                RentalOrderDetail originalOrder = dbInteraction.RentalOrderDetails.FirstOrDefault(order => order.OrderId == OrderID);
                if (originalOrder != null)
                {
                    updatedOrder.OrderId = originalOrder.OrderId;
                    dbInteraction.Entry(originalOrder).CurrentValues.SetValues(updatedOrder);
                    dbInteraction.SaveChanges();
                    return Ok(updatedOrder);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpPut("[action]/{VehicleTypeID}")]
        public IActionResult UpdateVehicleType(int VehicleTypeID, [FromBody] VehicleType updatedVehicleType)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleType originalVehicleType = dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == VehicleTypeID);
                if (originalVehicleType != null)
                {
                    updatedVehicleType.VehicleTypeId = originalVehicleType.VehicleTypeId;
                    dbInteraction.Entry(originalVehicleType).CurrentValues.SetValues(updatedVehicleType);
                    dbInteraction.SaveChanges();
                    return Ok(updatedVehicleType);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpPut("[action]/{VehicleID}")]
        public IActionResult UpdateVehicle(int VehicleID, [FromBody] VehicleInventory updatedVehicle)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleInventory originalVehicleType = dbInteraction.VehicleInventories.FirstOrDefault(vehicle => vehicle.VehicleId == VehicleID);
                if (originalVehicleType != null)
                {
                    updatedVehicle.VehicleId = originalVehicleType.VehicleId;
                    dbInteraction.Entry(originalVehicleType).CurrentValues.SetValues(updatedVehicle);
                    dbInteraction.SaveChanges();
                    return Ok(updatedVehicle);
                }
                else
                {
                    return NoContent();
                }
            }
        }


        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
