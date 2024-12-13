using TrackFlow.Entities;

namespace TrackFlow.DTO
{
    public class VehicleDTO
    {

        public required string Registration { get; init; } = string.Empty;
        public required double Capacity {  get; init; }

        public required string Fuel {  get; init; } = string.Empty;

        public virtual Driver? Driver { get; set; }
    }
}
