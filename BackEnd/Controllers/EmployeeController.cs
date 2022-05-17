using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling Web  for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class EmployeeController : ControllerBase
    {


        // GET /Employee/GetOrderWithMatchingSerialNumber,<string>
        [HttpGet("[action],{orderSerialNumber}")]
        public IActionResult GetOrderWithMatchingSerialNumber(string orderSerialNumber)
         {
            using(CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext()) 
            {
                RentalOrderDetail matchinOrder = DBInteraction.RentalOrderDetails.FirstOrDefault(order => order.SerialNumber == orderSerialNumber && (order.DateOfficiallyReturned == null || order.DateOfficiallyReturned == ""));

                if (matchinOrder != null)
                {
                    return Ok(matchinOrder);
                }
                else 
                {
                    return StatusCode(404);
                }
            }
        }


        // GET Employee/GetVehicleTypeWithMatchingSerialNumber<string>
        [HttpGet("[action],{orderSerialNumber}")]
        public IActionResult GetVehicleTypeWithMatchingSerialNumber(string orderSerialNumber)
        {
            using (CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext()) 
            {
                VehicleInventory matchingVehicle = DBInteraction.VehicleInventories.Where(Vehicle => Vehicle.SerialNumber == orderSerialNumber).SingleOrDefault();
             
                if (matchingVehicle == null) return StatusCode(404);
                VehicleType matchingVehicleType = DBInteraction.VehicleTypes.FirstOrDefault(vehicleType => vehicleType.VehicleTypeId == matchingVehicle.VehicleTypeId);
                return Ok(matchingVehicleType);
            }
        }

        // PUT /Employee/CloseOrder
        [HttpPut("[action]")]
        public IActionResult CloseOrder([FromBody] RentalOrderDetail returnedOrder)
        {
            using (CarRentalDatabaseContext DBInteraction = new CarRentalDatabaseContext()) 
            {
                VehicleInventory matchingVehicle = DBInteraction.VehicleInventories.Where(Vehicle => Vehicle.SerialNumber == returnedOrder.SerialNumber).SingleOrDefault();
                if (matchingVehicle == null || matchingVehicle.Available == true) return StatusCode(404, "Vehicle was already returned");
                matchingVehicle.Available = true;

                RentalOrderDetail matchingOrder = DBInteraction.RentalOrderDetails.FirstOrDefault(order => order.SerialNumber == returnedOrder.SerialNumber && order.DateOfficiallyReturned == null);
                if(matchingVehicle == null || returnedOrder.DateOfficiallyReturned == null) return StatusCode(404);

                matchingOrder.DateOfficiallyReturned = returnedOrder.DateOfficiallyReturned;
                DBInteraction.SaveChanges();

                return Ok();
            }
        }
    }
}
