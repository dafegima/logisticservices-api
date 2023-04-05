namespace LogisticService.Domain.Entities
{
    public class ServiceEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }
        public string Destination { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
    }
}