using Microsoft.AspNetCore.Mvc;
using PosBookingBackEnd.Interfaces;
using PosBookingBackEnd.Model.Requests;
using PosBookingBackEnd.Services;

namespace PosBookingBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        IBookingService bookingService;
        public BookingController(IBookingService bookingService) {
            this.bookingService = bookingService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetBookingsRequest request)
        {
            return Ok(bookingService.GetBookings(request));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostBookingRequest request)
        {
            return Ok(bookingService.InsertBooking(request));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateBookingRequest request)
        {
            return Ok(bookingService.UpdateBooking(request));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBookingRequest request)
        {
            bookingService.DeleteBooking(request);
            return Ok();
        }

    }
}
