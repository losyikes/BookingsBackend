using PosBookingBackEnd.Model;
using System.Collections.ObjectModel;

namespace PosBookingBackEnd.Interfaces
{
    public interface IBookingTypeService
    {
        public List<BookingType> GetBookingTypes();
    }
}
