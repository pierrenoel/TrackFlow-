namespace TrackFlow.Entities
{
    public class Itenerary
    {
        public string VehicleId { get; set; } = string.Empty;
        public Guid DriverId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
