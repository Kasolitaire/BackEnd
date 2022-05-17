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
                    return StatusCode(404, "Table doesn't exist");
            }
        }

        // POST /Admin/PostNewOrder
        [HttpPost("[action]")]
        public IActionResult PostNewOrder([FromBody] RentalOrderDetail newOrder)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                newOrder.OrderId = 0;
                VehicleInventory matchingVehicle = dbInteraction.VehicleInventories.FirstOrDefault(vehicle => vehicle.SerialNumber == newOrder.SerialNumber);
                if (matchingVehicle == null) return StatusCode(404, "Order must correspond to vehicle with a matching serial number");

                User matchingUser = dbInteraction.Users.FirstOrDefault(user => user.UserId == newOrder.UserId);
                if (matchingUser == null) return StatusCode(404, "Order must correspond to a user with a matching UserID");

                dbInteraction.RentalOrderDetails.Add(newOrder);
                dbInteraction.SaveChanges();

                return Ok(newOrder);
            }
        }

        // POST /Admin/PostNewVehicle
        [HttpPost("[action]")]
        public IActionResult PostNewVehicle([FromBody] VehicleInventory newVehicle) 
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                newVehicle.VehicleId = 0;

                VehicleInventory matchingVehicle = dbInteraction.VehicleInventories.FirstOrDefault(vehicle => vehicle.SerialNumber == newVehicle.SerialNumber);
                if (matchingVehicle != null) return StatusCode(404, "Cannot have two vehicles with the same serial number");

                VehicleType matchingVehicleType = dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == newVehicle.VehicleTypeId);
                if (matchingVehicleType == null) return StatusCode(404, "Vehicle must correspond to a vehicle type with a matching vehicleTypeId");

                dbInteraction.VehicleInventories.Add(newVehicle);
                dbInteraction.SaveChanges();
                return Ok(newVehicle);
            }
        }

        // POST /Admin/PostNewVehicleType
        [HttpPost("[action]")]
        public IActionResult PostNewVehicleType([FromBody] VehicleType newType) 
        {
            newType.VehicleTypeId = 0;
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            { 
                dbInteraction.VehicleTypes.Add(newType);
                dbInteraction.SaveChanges();
                return Ok();
            }
        }


        // PUT Admin/UpdateUser
        [HttpPut("[action]")]
        public IActionResult UpdateUser([FromBody] User updatedUser)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                User originalUser = dbInteraction.Users.FirstOrDefault(user => user.UserId == updatedUser.UserId);
                if (originalUser != null) 
                {
                    updatedUser.UserId = originalUser.UserId;
                    dbInteraction.Entry(originalUser).CurrentValues.SetValues(updatedUser);
                    dbInteraction.SaveChanges();
                    return Ok(updatedUser);
                }
                else
                {
                    return StatusCode(404, "User does not exist");
                }
            }
        }

        // PUT Admin/UpdateOrder
        [HttpPut("[action]")]
        public IActionResult UpdateOrder([FromBody] RentalOrderDetail updatedOrder)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                RentalOrderDetail originalOrder = dbInteraction.RentalOrderDetails.FirstOrDefault(order => order.OrderId == updatedOrder.OrderId);
                VehicleInventory matchingVehicle = dbInteraction.VehicleInventories.FirstOrDefault(Vehicle => Vehicle.SerialNumber == updatedOrder.SerialNumber);
                if (matchingVehicle == null) return StatusCode(404, "Update serial number must correspond to vehicle with a matching serial number");
                
                User matchingUser = dbInteraction.Users.FirstOrDefault(user => user.UserId == updatedOrder.UserId);
                if (matchingUser == null) return StatusCode(404, "Updated UserID must correspond to a user with a matching UserID");
                
                if (originalOrder != null)
                {
                    updatedOrder.OrderId = originalOrder.OrderId;
                    dbInteraction.Entry(originalOrder).CurrentValues.SetValues(updatedOrder);
                    dbInteraction.SaveChanges();
                    return Ok(updatedOrder);
                }
                else
                {
                    return StatusCode(404, "Order does not exist");
                }
            }
        }

        // PUT Admin/UpdateVehicleType
        [HttpPut("[action]")]
        public IActionResult UpdateVehicleType([FromBody] VehicleType updatedVehicleType)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleType originalVehicleType = dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == updatedVehicleType.VehicleTypeId);
                if (originalVehicleType != null)
                {
                    updatedVehicleType.VehicleTypeId = originalVehicleType.VehicleTypeId;
                    dbInteraction.Entry(originalVehicleType).CurrentValues.SetValues(updatedVehicleType);
                    dbInteraction.SaveChanges();
                    return Ok(updatedVehicleType);
                }
                else
                {
                    return StatusCode(404, "Vehicle type does not exist");
                }
            }
        }

        // PUT Admin/UpdateVehicle
        [HttpPut("[action]")]
        public IActionResult UpdateVehicle([FromBody] VehicleInventory updatedVehicle)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleType matchingVehicleType = dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == updatedVehicle.VehicleTypeId);
                if (matchingVehicleType == null) return StatusCode(404, "Updated VehicleTypeId must correspond with a matching VehicleTypeId");
                
                VehicleInventory originalVehicleType = dbInteraction.VehicleInventories.FirstOrDefault(vehicle => vehicle.VehicleId == updatedVehicle.VehicleId);
                if (originalVehicleType != null)
                {
                    updatedVehicle.VehicleId = originalVehicleType.VehicleId;
                    dbInteraction.Entry(originalVehicleType).CurrentValues.SetValues(updatedVehicle);
                    dbInteraction.SaveChanges();
                    return Ok(updatedVehicle);
                }
                else
                {
                    return StatusCode(404, "Vehicle does not exist");
                }
            }
        }
        
        // DELETE /Admin/DeleteUser/<int>
        [HttpDelete("[action],{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                 User matchingUser = dbInteraction.Users.FirstOrDefault(user => user.UserId == userId);

                if (matchingUser == null) return StatusCode(404, "User doesn't exist");
                
                dbInteraction.Users.Remove(matchingUser);
                dbInteraction.SaveChanges();
                return Ok();
            }
        }

        // DELETE /Admin/DeleterOrder/<int>
        [HttpDelete("[action],{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                RentalOrderDetail matchingOrder = dbInteraction.RentalOrderDetails.FirstOrDefault(order => order.OrderId == orderId);

                if (matchingOrder == null) return StatusCode(404, "Order doesn't exist");

                dbInteraction.RentalOrderDetails.Remove(matchingOrder);
                dbInteraction.SaveChanges();
                return Ok();
            }
        }

        // DELETE /Admin/DeleterVehicle/<int>
        [HttpDelete("[action],{vehicleId}")]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleInventory matchingVehicle = dbInteraction.VehicleInventories.FirstOrDefault(vehicle => vehicle.VehicleId == vehicleId);

                if (matchingVehicle == null) return StatusCode(404, "Vehicle doesn't exist");

                dbInteraction.VehicleInventories.Remove(matchingVehicle);
                dbInteraction.SaveChanges();
                return Ok();
            }
        }

        // DELETE /Admin/DeleteVehicleType/<int>
        [HttpDelete("[action],{vehicleTypeId}")]
        public IActionResult DeleteVehicleType(int vehicleTypeId)
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                VehicleType matchingVehicleType = dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == vehicleTypeId);

                if (matchingVehicleType == null) return StatusCode(404, "Type doesn't exist");

                dbInteraction.VehicleTypes.Remove(matchingVehicleType);
                dbInteraction.SaveChanges();
                return Ok();
            }
        }
    }
}
