namespace PosBookingBackEnd.Model.Requests
{
    public class GetBookingsRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
