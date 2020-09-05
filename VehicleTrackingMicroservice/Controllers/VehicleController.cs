using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using VehicleTrackingBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTrackingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // GET: api/<VehicleController>
        // vehicle object will contains the search criteria
        [HttpGet]
        public IEnumerable<Vehicle> Get([FromBody] Vehicle vehicle)
        {
            List<Vehicle> lstVehicle = new List<Vehicle>();
            VTBL obj = new VTBL();
            lstVehicle = obj.SearchVehicles(vehicle);
            return lstVehicle;
        }
       
    }
}
