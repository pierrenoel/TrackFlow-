using Microsoft.EntityFrameworkCore;
using TrackFlow.Data;
using TrackFlow.DTO;
using TrackFlow.Entities;

namespace TrackFlow.Services
{

    public interface IServiceVehicule
    {
        public Task<List<Vehicle>> GetVehicles();
        public Task<Vehicle?> GetVehicle(string registration);

        public Task<Vehicle> AddVehicle(Vehicle vehicle);
    }

    public class ServiceVehicle : IServiceVehicule
    {
        private readonly ContextTrackFlow _context;

        public ServiceVehicle(ContextTrackFlow context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetVehicle(string registration)
        {

            return await _context.Vehicles.FindAsync(registration);
                          
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);

            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
