namespace PosBookingBackEnd.Model.Requests
{
    public class UpdateBookingRequest
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Note { get; set; }
    }
}
