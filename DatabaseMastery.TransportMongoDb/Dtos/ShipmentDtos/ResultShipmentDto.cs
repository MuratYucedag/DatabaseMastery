namespace DatabaseMastery.TransportMongoDb.Dtos.ShipmentDtos
{
    public class ResultShipmentDto
    {
        public string ShipmentId { get; set; }

        public string TrackingNumber { get; set; }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CurrentStatus { get; set; }
    }
}
