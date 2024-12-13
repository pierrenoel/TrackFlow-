using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackFlow.Data;
using TrackFlow.DTO;
using TrackFlow.Entities;
using TrackFlow.Services;

namespace TrackFlow.Controllers
{
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IServiceVehicule _service;

        public VehicleController(IServiceVehicule service)
        {
            _service = service;
        }

        // Retrive all the vehicles
        [HttpGet]
        [Route("api/vehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            var vehicles = await _service.GetVehicles();

            return Ok(vehicles); 
        }

        // Retrive only one vehicle
        [HttpGet]
        [Route("api/vehicle/{registration}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(string registration)
        {
            Vehicle vehicle = await _service.GetVehicle(registration);

            if(vehicle == null) return NotFound();

            return Ok(vehicle);
        }

        // Add into the database
        [HttpPost]
        [Route("api/vehicle")]
        public async Task<ActionResult<Vehicle>> AddVehicule(Vehicle vehicle)
        {
            Vehicle res = await _service.AddVehicle(vehicle);

            return CreatedAtAction(nameof(GetVehicle), new { registration = res.Registration}, res);
        }
    }
}
