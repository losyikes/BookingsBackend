using PosBookingBackEnd.Helpers;
using PosBookingBackEnd.Interfaces;
using PosBookingBackEnd.Model;
using PosBookingBackEnd.Model.Requests;
using System.Collections.ObjectModel;

namespace PosBookingBackEnd.Services
{
    public class BookingService : IBookingService
    {
        List<Booking> bookings = new List<Booking>();
        List<BookingType> bookingTypes = new List<BookingType>();
        DataStorage storage = new DataStorage();

        public BookingService() 
        {
            this.bookings = storage.Bookings;
        }
        public List<Booking> GetBookings(GetBookingsRequest request)
        {
            List<Booking> myBookings = storage.Bookings.Where(x => x.StartTime.Date >= request.StartTime.Date && x.EndTime.Date <= request.EndTime.Date).ToList();
            return myBookings;
        }

        public List<BookingType> GetBookingTypes()
        {
            return bookingTypes.ToList();
        }

        public Booking InsertBooking(PostBookingRequest request)
        {
            int maxId = storage.Bookings.OrderByDescending(x => x.Id).First().Id;
            Booking booking = new Booking() { 
                Id = maxId + 1, 
                CustomerName = request.CustomerName, 
                CustomerPhone = request.CustomerPhone, 
                StartTime = request.StartTime, 
                EndTime = request.EndTime, 
                Type = storage.BookingTypes.Single(x => x.Id == request.TypeId), 
                Note = request.Note
            };
            storage.Bookings.Add(booking);
            storage.SaveBookings();
            return booking;
        }

        public Booking? UpdateBooking(UpdateBookingRequest request)
        {
            Booking? oldBooking = storage.Bookings.SingleOrDefault(x => x.Id == request.Id);
            var booking = oldBooking;

            if (oldBooking != null && booking != null)
            {
                var index = storage.Bookings.ToList().FindIndex(x => x.Id == oldBooking.Id);
                if (request.CustomerName != null)
                {
                    booking.CustomerName = request.CustomerName;
                };
                if(request.CustomerPhone != null) 
                {
                    booking.CustomerPhone = request.CustomerPhone;
                }
                if(request.StartTime != null)
                {
                    booking.StartTime = (DateTime)request.StartTime;
                }
                if(request.EndTime != null)
                {
                    booking.EndTime = (DateTime)request.EndTime;
                }
                if(request.TypeId != null)
                {
                    BookingType? bookingType = bookingTypes.SingleOrDefault(y => y.Id == request.TypeId);
                    if(bookingType != null)
                    {
                        booking.Type = bookingType;
                    }
                }
                if(request.Note != null)
                {
                    booking.Note = request.Note;
                }
                storage.Bookings.Remove(oldBooking);
                storage.Bookings.Add(booking);
                storage.SaveBookings();
            }
            return booking;
        }
        public void DeleteBooking(DeleteBookingRequest request)
        {
            Booking chosenBooking = bookings.SingleOrDefault(x => x.Id == request.Id);
            if(chosenBooking != null)
            {
                storage.Bookings.Remove(chosenBooking);
            }
        }
    }
}
