namespace PosBookingBackEnd.Model.Requests
{
    public class PostBookingRequest
    {
        public required int TypeId { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Note { get; set; }
    }
}
