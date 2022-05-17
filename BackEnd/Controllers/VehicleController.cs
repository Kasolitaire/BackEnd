using Microsoft.AspNetCore.Mvc;
using DatabaseHandler;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // GET: /Vehicle/GetAvailableVehicles
        [HttpGet("[action]")]
        //Returns all the vehicles that are both available & operational
        public IActionResult GetAvailableVehicles()
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext()) 
            {
                try
                {
                    List<VehicleInventory> availableVehicleList = dbInteraction.VehicleInventories.Where(vehicle => vehicle.Available == true && vehicle.Operational == true).ToList();
                    return Ok(availableVehicleList);
                }
                catch (System.Exception error)
                {
                    return StatusCode(500, error.Message);
                }
            }
        }

        //Get: /Vehicle/GetAllAvailableVehicleTypes
        [HttpGet("[action]")]
        //Returns all the vehicle types
        public IActionResult GetAllAvailableVehicleTypes() 
        {
            using (CarRentalDatabaseContext dbInteraction = new CarRentalDatabaseContext())
            {
                try
                {
                    List<VehicleInventory> availableVehicleList = dbInteraction.VehicleInventories.Where(vehicle => vehicle.Available == true && vehicle.Operational == true).ToList();
                    List<VehicleType> availableVehicleTypesList = new List<VehicleType>();
                    foreach(VehicleInventory vehicle in availableVehicleList)
                    {
                        availableVehicleTypesList.Add(dbInteraction.VehicleTypes.FirstOrDefault(type => type.VehicleTypeId == vehicle.VehicleTypeId));
                    }
                    availableVehicleTypesList = availableVehicleTypesList.Distinct().ToList();
                    return Ok(availableVehicleTypesList);    
                }
                catch (System.Exception error)
                {
                    return StatusCode(500, error.Message);             
                }
            }
        }
    }
}
