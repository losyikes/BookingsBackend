using PosBookingBackEnd.Helpers;
using PosBookingBackEnd.Interfaces;
using PosBookingBackEnd.Model;
using System.Collections.ObjectModel;

namespace PosBookingBackEnd.Services
{
    public class BookingTypeService : IBookingTypeService
    {
        List<BookingType> bookingTypes = new List<BookingType>();
        public BookingTypeService() 
        {
            DataStorage dataStorage = new DataStorage();
            this.bookingTypes = dataStorage.BookingTypes;
        }
        public List<BookingType> GetBookingTypes()
        {
            return this.bookingTypes;
        }
    }
}
