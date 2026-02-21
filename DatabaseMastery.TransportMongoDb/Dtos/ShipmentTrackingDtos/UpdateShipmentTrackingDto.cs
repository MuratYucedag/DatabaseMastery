namespace DatabaseMastery.TransportMongoDb.Dtos.ShipmentTrackingDtos
{
    public class UpdateShipmentTrackingDto
    {
        public string TrackingNumber { get; set; }  // Hangi kargo
        public int TrackingIndex { get; set; }       // Listede kaçıncı hareket
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TrackingStatus { get; set; }
    }
}
