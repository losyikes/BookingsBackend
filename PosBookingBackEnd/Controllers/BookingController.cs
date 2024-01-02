using Microsoft.AspNetCore.Mvc;
using PosBookingBackEnd.Interfaces;
using PosBookingBackEnd.Model;
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
            Booking? booking = bookingService.InsertBooking(request);
            if(booking == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateBookingRequest request)
        {
            Booking? booking = bookingService.UpdateBooking(request);
            if(booking == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(booking);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            bool isDeleted = bookingService.DeleteBooking(id);
            if (isDeleted)
            {
                return Ok();

            }
            else
            {
                return NotFound();
            }
        }

    }
}
