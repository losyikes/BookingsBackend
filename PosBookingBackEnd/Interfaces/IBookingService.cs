using PosBookingBackEnd.Model;
using PosBookingBackEnd.Model.Requests;

namespace PosBookingBackEnd.Interfaces
{
    public interface IBookingService
    {
        public List<Booking> GetBookings(GetBookingsRequest request);
        public Booking? UpdateBooking(UpdateBookingRequest request);
        public Booking InsertBooking(PostBookingRequest request);
        public bool DeleteBooking(int id);
    }
}
